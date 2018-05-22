using DesktopWarrior.DAL.Interfaces;
using DesktopWarrior.DAL.Repositories;
using System.Web.Mvc;
using DesktopWarrior.Models.ViewModels;

namespace DesktopWarrior.Controllers
{
    public class HomeController : Controller
    {

        private IProductRepository _repository;
        private ICategoryRepository _categoryRep;
        public HomeController()
        {
            _repository = new ProductRepository(new DAL.DesktopGuysContext());
            _categoryRep = new CategoryRepository(new DAL.DesktopGuysContext());
        }

        public ActionResult Index()
        {
            int categoryId = 3;
            var category = _categoryRep.GetCategoryById(categoryId);
            var products = _repository.GetProductsByCategory(categoryId);
            return View(new HomeViewModel() { Products = products, Category = category });
        }
    }
}