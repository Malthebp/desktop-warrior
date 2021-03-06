﻿using DesktopWarrior.Models.ViewModels.BuildYourRig;
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
            Byr byr = null;

            if (controllerContext.HttpContext.Session != null)
            {
                byr = (Byr)controllerContext.HttpContext.Session[sessionKey];
            }
            // create the Cart if there wasn't one in the session data
            if (byr == null)
            {
                byr = new Byr();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = byr;
                }
            }

            // return the cart
            return byr;
        }
    }
}