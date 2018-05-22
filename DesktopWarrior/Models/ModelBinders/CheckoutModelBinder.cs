using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesktopWarrior.Models.ModelBinders
{
    public class CheckoutModelBinder : IModelBinder
    {
        private const string sessionKey = "Checkout";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // get the Cart from the session
            Checkout checkout = null;

            if (controllerContext.HttpContext.Session != null)
            {
                checkout = (Checkout)controllerContext.HttpContext.Session[sessionKey];
            }
            // create the Cart if there wasn't one in the session data
            if (checkout == null)
            {
                checkout = new Checkout();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = checkout;
                }
            }

            // return the cart
            return checkout;
        }
    }
}