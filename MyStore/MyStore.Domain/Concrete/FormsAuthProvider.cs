using MyStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace MyStore.Domain.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        private EFDbContext context = new EFDbContext();
        
        public bool Authenticate(string email, string password, bool rememberMe)
        {
            Entities.User user;

            //original
            user = context.Users
                  .SqlQuery($"SELECT * FROM Users Where Email = '{email}' and Password = '{password}'")
                  .OrderByDescending(x => x.Email)
                  .FirstOrDefault();
            //todo: Session-3-1 SQL Injection Fix
            //fix 1: Parameter
            //user = AuthenticateUserFix1(email, password);

            //fix 2: LINQ
            //user = AuthenticateUserFix2(email, password);

            bool isValidUser = false;
            if(user != null)
            {
                isValidUser = true;
                var expirationDate = rememberMe ? DateTime.Now.AddDays(2) : DateTime.Now.AddMinutes(30);
                //todo: Session-10 Fix Save Pwd in cookie
                var authTicket = new FormsAuthenticationTicket(
                  1,
                  user.Email,
                  DateTime.Now,
                  expirationDate,
                  //rememberMe,  
                  false,
                  (user.IsAdmin.HasValue? user.IsAdmin.Value : false) ? "Admin": "User",
                  "/");
                var encryptedTicket = FormsAuthentication.Encrypt(authTicket); 
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                //if (rememberMe)
                //{
                //    cookie.Expires = expirationDate;
                //}
                HttpContext.Current.Response.Cookies.Add(cookie);
                //FormsAuthentication.SetAuthCookie(user.Email, rememberMe);
            }
            
            return isValidUser;
        }

        
        //todo: Session-3-1.1 SQL Injection Fix by Parameters
        private Entities.User AuthenticateUserFix1(string email, string password)
        {
            var user = context.Users
                .SqlQuery($"SELECT * FROM Users Where Email = @p0 and Password = @p1"
                , email, password)
                .FirstOrDefault();
            return user;
        }

        //todo: Session-3-1.2 SQL Injection Fix by LINQ
        private Entities.User AuthenticateUserFix2(string email, string password)
        {
            var user = context.Users
                .FirstOrDefault(u => u.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase)
                                    && u.Password.Equals(password));
            return user;
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

    }


}
