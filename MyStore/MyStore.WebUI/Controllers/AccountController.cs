using MyStore.Domain.Abstract;
using MyStore.Domain.Entities;
using MyStore.WebUI.ExtensionMethods;
using MyStore.WebUI.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyStore.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAuthProvider authProvider;
        private readonly IUserRepository userRepository;
        public AccountController(IAuthProvider authProvider,
            IUserRepository userRepository)
        {
            this.authProvider = authProvider;
            this.userRepository = userRepository;
        }

        [AllowAnonymous]
        public ViewResult Login()
        {
            ViewBag.Users = userRepository.Users;
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            //var pw2 = model.Password2.ToText();
            ViewBag.Users = userRepository.Users;
            
            if (ModelState.IsValid)
            {
                
                if(authProvider.Authenticate(model.Email, model.Password, model.RememberMe))
                {
                    //Session.Abandon();
                    //Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                    //todo: Session-8.3 InSecurity Deserialization Fix - UserInfo write cookie
                    var userInfo = JsonConvert.SerializeObject(new
                    {
                        Email = model.Email,
                        IsAdmin = User.IsInRole("Admin")
                    });
                    Response.Cookies.Add(new HttpCookie("userInfo", HttpUtility.UrlEncode(userInfo)) );

                    // login success
                    // Change the auth cookie to remove the HttpOnly attribute Demo Only
                    var authCookieName = FormsAuthentication.FormsCookieName;
                    //todo:Fix A6 HttpOnly
                    //Response.Cookies[authCookieName].HttpOnly = false;

                    //todo: Session-10 Fix Save Pwd in cookie
                    if (model.RememberMe)
                    {
                        var bytesToEncode = Encoding.UTF8.GetBytes(model.Password);
                        var encodedPassword = Convert.ToBase64String(bytesToEncode);

                        Response.Cookies.Add(new HttpCookie("Password", encodedPassword) { Expires = DateTime.Now.AddYears(1) });
                        Response.Cookies.Add(new HttpCookie("Email", model.Email) { Expires = DateTime.Now.AddYears(1) });
                    }
                    else
                    {
                        Response.Cookies.Remove("Password");
                        Response.Cookies.Remove("Email");
                    }

                    return Redirect(returnUrl ?? Url.Action("List", "Product"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        //todo: Session-5.8 暴力/字典破解修正
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> LoginFix(LoginViewModel model, string returnUrl)
        {
            ViewBag.Users = userRepository.Users;
            // incremental delay to prevent brute force attacks
            int incrementalDelay;
            //Request.UserHostAddress為Client的IP Address
            if (HttpContext.Application[Request.UserHostAddress] != null)
            {
                incrementalDelay = (int)HttpContext.Application[Request.UserHostAddress];
                if(incrementalDelay > 2)
                {
                    await Task.Delay(incrementalDelay * 2000);
                }
            }

            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.Email, model.Password, model.RememberMe))
                {
                    // login success
                    // reset incremental delay on successful login
                    if (HttpContext.Application[Request.UserHostAddress] != null)
                    {
                        HttpContext.Application.Remove(Request.UserHostAddress);
                    }

                    //Session.Abandon();
                    //Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));

                    // Change the auth cookie to remove the HttpOnly attribute
                    var authCookieName = FormsAuthentication.FormsCookieName;
                    Response.Cookies[authCookieName].HttpOnly = false;
                    if (model.RememberMe)
                    {
                        var bytesToEncode = Encoding.UTF8.GetBytes(model.Password);
                        var encodedPassword = Convert.ToBase64String(bytesToEncode);

                        Response.Cookies.Add(new HttpCookie("Password", encodedPassword) { Expires = DateTime.Now.AddYears(1) });
                        Response.Cookies.Add(new HttpCookie("Email", model.Email) { Expires = DateTime.Now.AddYears(1) });
                    }
                    else
                    {
                        Response.Cookies.Remove("Password");
                        Response.Cookies.Remove("Email");
                    }

                    return Redirect(returnUrl ?? Url.Action("List", "Product"));
                }
                else
                {
                    // login failed
                    // increment the delay on failed login attempts
                    if (HttpContext.Application[Request.UserHostAddress] == null)
                    {
                        incrementalDelay = 1;
                    }
                    else
                    {
                        incrementalDelay = (int)HttpContext.Application[Request.UserHostAddress] + 1;
                    }
                    HttpContext.Application[Request.UserHostAddress] = incrementalDelay;
                    ModelState.AddModelError("", $"Incorrect username or password, 失敗次數:{incrementalDelay}, ip:{Request.UserHostAddress}");
                }
            }
            return View();
        }

        [AllowAnonymous]
        public ViewResult Register()
        {
            ViewBag.Title = "Register User";
            return View("Edit", new User());
        }

        public ViewResult Edit(int userId)
        {
            var user = userRepository.Users
                .FirstOrDefault(p => p.UserID == userId);
            //todo: Session-7.1 修改使用者修正
            //var user = userRepository.Users
            //    .FirstOrDefault(u =>
            //    string.Compare(u.Email, User.Identity.Name
            //    , StringComparison.InvariantCultureIgnoreCase) == 0);
            ViewBag.Title = "Edit User";
            return View(user);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateInput(false)]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                //todo: Session-7.2 修改使用者存檔修正
                //if (!User.Identity.IsAuthenticated)
                //{
                //    user.UserID = 0;
                //}
                //else
                //{
                //    var authUser = userRepository.Users
                //        .FirstOrDefault(u =>
                //        string.Compare(u.Email, User.Identity.Name
                //        , StringComparison.InvariantCultureIgnoreCase) == 0);
                //    user.UserID = authUser.UserID;
                //}
                try
                {
                    var subject = "";
                    
                    if (user.UserID != 0)
                    {
                        subject = $"{user.Email}的帳號已修改";
                        TempData["message"] = subject;
                        
                    }
                    else
                    {
                        subject = $"{user.Email}的帳號已建立";
                        TempData["message"] = subject;
                    }
                    userRepository.SaveUser(user);
                    
                    var body = new StringBuilder()
                        .AppendLine($"您好 {user.FirstName},")
                        .AppendLine(subject)
                        //todo: Session-5.3 Mail內容不能包含 Password
                        .AppendLine($"請不要忘記，您的密碼為<strong>{user.Password}</strong>")
                        .AppendLine($"使用新的密碼登入 http://localhost:44375/Account/Login 系統");
                    userRepository.NotifyUser(user.Email, subject, body.ToString());
                    return RedirectToAction("Login");
                }catch(Exception e)
                {
                    TempData["message"] = "";
                    ModelState.AddModelError("", e.ToString());
                }
            }
            return View(user);
        }

        [AllowAnonymous]
        public PartialViewResult UserProfiler()
        {
            User user = null;
            if(User.Identity.IsAuthenticated)
            {
                user = userRepository.Users.FirstOrDefault(u => string.Compare(u.Email, User.Identity.Name, StringComparison.InvariantCultureIgnoreCase) == 0);  
            }
            if (user == null)
            {
                user = new User();
            }
            return PartialView(user);
        }


        [HttpPost]
        public ActionResult LogOff()
        {
            authProvider.SignOut();
            //清除所有的 session
            Session.Abandon();
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            return RedirectToAction("List", "Product");
        }


        public ViewResult ChangePassword()
        {
            ViewBag.ReturnUrl = Url.Action("ChangePassword");
            var user = userRepository.Users.FirstOrDefault(u => string.Compare(u.Email, User.Identity.Name, StringComparison.InvariantCultureIgnoreCase) == 0);
            return View(new PasswordViewModel { NewPassword = user?.Password, ConfirmPassword = user?.Password });
            //todo: Session-5.7 don't load user's password
            //return View(new PasswordViewModel());
        }

        [HttpPost]
        //todo: Session-9.1 Cross Site Request Forgery Fix (FORM)
        //[ValidateAntiForgeryToken]
        public ActionResult ChangePassword(PasswordViewModel model)
        {
            ViewBag.ReturnUrl = Url.Action("ChangePassword");
            if (ModelState.IsValid)
            {
                // ChangePassword will throw an exception rather than return false in certain failure scenarios.
                bool changePasswordSucceeded = true;
                try
                {
                    var user = userRepository.Users.FirstOrDefault(u => string.Compare(u.Email, User.Identity.Name, StringComparison.InvariantCultureIgnoreCase) == 0);
                    //if(user.Password != model.CurrentPassword)
                    //{
                    //    throw new Exception("current password is incorrect");
                    //}
                    user.Password = model.NewPassword;
                    userRepository.SaveUser(user);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    TempData["message"] = $"Your password has been changed.";
                    return RedirectToAction("ChangePassword");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            return View(model);
        }

        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult ResetPassword(PasswordResetModel model)
        {
            var user = userRepository.Users.SingleOrDefault(u => u.Email == model.Email);
            var subject = "";
            var body = new StringBuilder();
            if (user != null)
            {
                user.Password = DateTime.Now.ToString("yyyyMMdd");
                userRepository.SaveUser(user);
                subject = "密碼重設";
                body.AppendLine($"Hi {user.FirstName}!<br /><br />");
                body.AppendLine($"{user.Email}的密碼已被重設成<b>{user.Password}</b><br /><br />");
                body.AppendLine($"請使用新密碼登入.<br /><br />");
                //通知使用者
                userRepository.NotifyUser(user.Email, subject, body.ToString());
                TempData["message"] = $"{user.Email} Password has been Reset, Please Login with new Password";
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", "The specified user does not exist.");
            }
            return View();
        }

        #region ResetPasswordFix

        //todo: Session-5.4 忘記密碼輸入Email，都顯示重設完成，並發送通知給使用者
        //todo: Session-5.5 忘記密碼輸入Email, 如果有使用者就產生一個 Token 在 Email 之中
        [HttpPost]
        [AllowAnonymous]
        public ActionResult ResetPasswordFix(PasswordResetModel model)
        {
            var user = userRepository.Users.SingleOrDefault(u => u.Email == model.Email);
            var subject = "";
            var body = new StringBuilder();
            if (user != null)
            {
                //todo:Session-5.6.1 Use RNGCryptoServiceProvider 密碼編譯亂數產生器
                user.Token = DateTime.Now.ToString("ddHHmmssf");
                //user.Token = CreateResetToken();
                user.TokenCreTime = DateTime.Now;
                userRepository.SaveUser(user);
                subject = "密碼重設";
                body.AppendLine($"Hi {user.FirstName}!<br /><br />");
                body.AppendLine("您（或其他人）輸入此電子郵件地址以重置您的帳戶密碼<br /><br />");
                body.AppendLine($"要繼續密碼重置過程，請按這個連結 <a href='http://localhost:44375/Account/VerifyResetToken/?token={user.Token}'>重設密碼</a>.<br /><br />");
            }
            else
            {
                subject = "You do not have an account";
                body.AppendLine("您（或其他人）輸入此電子郵件地址以重置您的帳戶密碼<br /><br />");
                body.AppendLine($"但是，此電子郵件地址在本網站上是沒有帳戶.<br /><br />");
            }
            body.AppendLine($"此操作是從IP {Request.UserHostAddress} 執行的. ");

            //通知使用者
            userRepository.NotifyUser(model.Email, subject, body.ToString());
            return View("ResetPasswordComplete");
        }


        //
        // GET: /Account/VerifyResetToken
        [AllowAnonymous]
        public ActionResult VerifyResetToken(string token)
        {
            return View(new PasswordResetVerificationViewModel { Token = token });
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult VerifyResetToken(PasswordResetVerificationViewModel model)
        {
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(model.Token))
            {
                var user = userRepository.GetUserFromResetToken(model.Token);
                if (user!=null)
                {
                    user.Token = null;
                    user.TokenCreTime = null;
                    user.Password = model.NewPassword;
                    userRepository.SaveUser(user);
                    return View("ResetComplete");
                }
            }
            return View("InvalidToken");
        }

        //todo: Session-5.6.2 使用時間的token，可改用 RNGCryptoServiceProvider(密碼編譯亂數產生器) 來產生亂數
        public static string CreateResetToken()
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[32];
            rng.GetBytes(buff);
            var salt = Convert.ToBase64String(buff);
            var hasher = SHA256.Create();
            var data = hasher.ComputeHash(Encoding.Default.GetBytes(salt));
            return BitConverter.ToString(data).Replace("-", "");
        }

        #endregion


    }
}