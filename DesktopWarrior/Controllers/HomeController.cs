using DesktopWarrior.DAL.Interfaces;
using DesktopWarrior.DAL.Repositories;
using System.Web.Mvc;
using DesktopWarrior.Models.ViewModels;
using DesktopWarrior.Models.ViewModels.BuildYourRig;

namespace DesktopWarrior.Controllers
{
    public class HomeController : Controller
    {

        private ICategoryRepository _categoryRep;
        private IProductRepository _repository;
        public HomeController()
        {
            _repository = new ProductRepository(new DAL.DesktopGuysContext());
        }
        public ActionResult Index()
        {
            var category = _categoryRep.GetCategoryById(4);
            var products = _repository.GetProductsByCategory(4);

            return View(new HomeViewModel() { Products = products, Category = category });
        }
    }
}