using MyStore.Domain.Entities;
using MyStore.WebUI.Binders;
using MyStore.WebUI.Infrastructure.Binders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace MyStore.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MvcHandler.DisableMvcResponseHeader = true;
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
            //ModelBinders.Binders.Add(typeof(System.Security.SecureString)
            //    , new SecureStringModelBinder());
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("VisitStart", DateTime.UtcNow.ToString()));
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie =
                Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket =
                                            FormsAuthentication.Decrypt(authCookie.Value);
                string[] roles = authTicket.UserData.Split(new Char[] { ',' });
                //todo: Session-8.3 InSecurity Deserialization Fix - UserInfo read
                var userInfoCookie = Context.Request.Cookies["userInfo"];
                if(userInfoCookie != null)
                {
                    var userInfoJson = HttpUtility.UrlDecode(userInfoCookie.Value);
                    var userInfo = JsonConvert.DeserializeAnonymousType(userInfoJson, new { Email = "", IsAdmin = false });
                    if (userInfo.IsAdmin)
                    {
                        Array.Resize(ref roles, roles.Length + 1);
                        roles[roles.Length - 1] = "Admin";
                    }
                }

                var userPrincipal =
                                 new GenericPrincipal(new GenericIdentity(authTicket.Name), roles);
                Context.User = userPrincipal;
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
            ////到這時，Url已被改成沒包含SessionId
            ////但它的值會放在 Response._appPathModifier 變數之中
            //var appPathModifierFieldInfo = Context.Response.GetType().GetField("_appPathModifier",
            //             BindingFlags.NonPublic | BindingFlags.Instance);
            //var appPathModifier = appPathModifierFieldInfo.GetValue(Context.Response);
            //if (appPathModifier != null)
            //{
            //    //url 中有 SessionId
            //    throw new HttpException(404, "Not found");
            //}

            ////deny HTTP GET with request body
            //if(Request.HttpMethod == "GET" && Request.ContentLength > 0)
            //{
            //    throw new HttpException(403, "Forbidden");
            //}
        }
    }
}
