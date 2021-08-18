using MyStore.Domain.Entities;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace MyStore.WebUI.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Cart cart = null;
            bool inWeb = false;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
                inWeb = true;
            }

            if(cart == null)
            {
                cart = new Cart();
                if(inWeb)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            return cart;
        }
    }
}