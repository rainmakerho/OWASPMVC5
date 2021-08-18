using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Attacker.MyStore.Controllers
{
    public class CookiesController : Controller
    {
        // GET: Cookies
        public ActionResult Index(string c)
        {
            ViewBag.CookieString = c;
            var cookieCollection = new HttpCookieCollection();
            if (!string.IsNullOrEmpty(c))
            {
                const char cookieDelimiter = ';';
                var nameValDelimiter = new[] { '=' };
                foreach(var cookie in c.Split(cookieDelimiter).Select(x => x.Split(nameValDelimiter, 2)).OrderBy(x => x[0]))
                {
                    cookieCollection.Add(new HttpCookie(cookie[0], cookie.Length > 1 ? cookie[1] : string.Empty));
                }
            }
            return View(cookieCollection);
        }
    }
}