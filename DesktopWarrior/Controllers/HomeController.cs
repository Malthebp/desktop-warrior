using DesktopWarrior.DAL.Interfaces;
using DesktopWarrior.DAL.Repositories;
using System.Web.Mvc;
using DesktopWarrior.Models.ViewModels;
using DesktopWarrior.Models.ViewModels.BuildYourRig;

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