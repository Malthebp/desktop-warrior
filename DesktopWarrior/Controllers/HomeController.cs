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
            _repository = new ProductRepository(new DAL.DesktopGuysContext());
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}