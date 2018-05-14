﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DesktopWarrior
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.LowercaseUrls = true;

            routes.MapRoute(
                name: "Product create",
                url: "auth/product/{action}/{productType}",
                defaults: new { controller = "Product", action = "AuthProductIndex", productType = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Auth",
                url: "auth/{controller}/{action}/{id}",
                defaults: new {controller = "Authentication", action = "Index", id = UrlParameter.Optional}
             );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
