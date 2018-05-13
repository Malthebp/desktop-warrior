using DesktopWarrior.DAL.Interfaces;
using DesktopWarrior.DAL.Repositories;
using DesktopWarrior.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesktopWarrior.Controllers
{
    public class HomeController : Controller
    {

        private IProductRepository _repository;
        public HomeController()
        {
            this._repository = new ProductRepository(new TESTContext());
        }
        public ActionResult Index()
        {
            return View(_repository.GetProductById(1));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}