using MyStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private readonly IProductRepository repository;

        public NavController(IProductRepository repository)
        {
            this.repository = repository;
        }


        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories =
                repository.Products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(c => c);
            //var viewName = horizontalLayout ? "MenuHorizontal" : "Menu";
            //var viewName = "FlexMenu";
            return PartialView("FlexMenu", categories);
        }
    }
}