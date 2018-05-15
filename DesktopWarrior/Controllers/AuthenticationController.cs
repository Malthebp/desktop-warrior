using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesktopWarrior.Controllers
{
    [Authorize]
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        // PARTIAL: Sidenavigation 
        public PartialViewResult GetSidenav()
        {
            return PartialView();
        }
    }
}