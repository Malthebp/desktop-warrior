using DesktopWarrior.Models.ViewModels.BuildYourRig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DesktopWarrior.Models.ModelBinders
{
    public class BuildYourRigModelBinder : IModelBinder
    {
        private const string sessionKey = "BuildYourRig";
        
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        { 
            // get the Cart from the session
            Bwr bwr = null;

            if (controllerContext.HttpContext.Session != null)
            {
                bwr = (Bwr)controllerContext.HttpContext.Session[sessionKey];
            }
            // create the Cart if there wasn't one in the session data
            if (bwr == null)
            {
                bwr = new Bwr();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = bwr;
                }
            }

            // return the cart
            return bwr;
        }
    }
}