using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Attacker.MyStore.Controllers
{
    public class WinSurfaceProController : Controller
    {
        // GET: WinSurfacePro
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email)
        {
            return View("SurfaceProWon");
        }
    }
}