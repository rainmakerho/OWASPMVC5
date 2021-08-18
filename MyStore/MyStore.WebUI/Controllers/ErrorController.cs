using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyStore.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        
        public ActionResult NotFound()
        {
            return View();
        }
 
    }
}