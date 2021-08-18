using MyStore.Domain.Abstract;
using MyStore.Domain.Entities;
using MyStore.WebUI.LogHelpers;
using MyStore.WebUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyStore.WebUI.Controllers
{
    
    public class CartController : Controller
    {
        private readonly IProductRepository repository;
        private readonly IOrderProcessor orderProcessor;
        private readonly IUserRepository userRepository;
        public CartController(IProductRepository repo, 
            IOrderProcessor orderProc,
            IUserRepository userRepository)
        {
            repository = repo;
            orderProcessor = orderProc;
            this.userRepository = userRepository;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart,int productId, string returnUrl)
        {
            var product = repository.Products.
                FirstOrDefault(p => p.ProductID == productId);

            if(product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, 
            int productId, string returnUrl)
        {
            var product = repository.Products.
                FirstOrDefault(p => p.ProductID == productId);

            if(product != null)
            {
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

         

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        [Authorize]
        public ViewResult Checkout()
        {
            ShippingDetails viewModel = new ShippingDetails();
            if (Request.Cookies["shippingDetail"] != null)
            {
                var shippingDetailJson = Request.Cookies["shippingDetail"].Value;
                if (shippingDetailJson.Length > 0)
                {
                    var serialSetting = new JsonSerializerSettings();
                    //todo: Session-8.3 Insecurity Deserialization Fix
                    //serialSetting.TypeNameHandling = TypeNameHandling.None;
                    serialSetting.TypeNameHandling = TypeNameHandling.Objects;
                    viewModel = JsonConvert.DeserializeObject<ShippingDetails>(HttpUtility.UrlDecode(shippingDetailJson), serialSetting);
                    viewModel.Others = "";
                }

            }
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                var user = userRepository.Users
                    .FirstOrDefault(u => string.Compare(u.Email, User.Identity.Name, StringComparison.InvariantCultureIgnoreCase) == 0);
                var order = orderProcessor.ProcessOrder(user, cart, shippingDetails);
                var shippingXML 
                    =$"<order><order_id>{order.OrderID}</order_id><email>{user.Email}</email></order>";
                ViewBag.ShippingXML = shippingXML;
                //save to cookie for cache
                var shippingDetail = JsonConvert.SerializeObject(shippingDetails, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
                var orders = JsonConvert.SerializeObject(cart);
                ElmahHelper.Log($"Order: {orders}, ShippingDetail:{shippingDetail}");

                cart.Clear();
                
                Response.Cookies.Add(new HttpCookie("shippingDetail", HttpUtility.UrlEncode( shippingDetail)) { Expires = DateTime.Now.AddDays(1) });
                
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }


        public ViewResult Orders()
        {
            return View(new List<Order>());
        }

        //public ViewResult Completed()
        //{
        //    var shippingXML
        //            = $"<order><order_id>123</order_id><email>rm@gss.com.tw</email></order>";
        //    ViewBag.ShippingXML = shippingXML;
        //    return View();
        //}

        [HttpPost]
        public ViewResult Orders(string productName)
        {
            var orders = orderProcessor.SearchOrders(User.Identity.Name
                , productName);
            ViewBag.Search = productName;
            return View(orders);
        }

    }
}