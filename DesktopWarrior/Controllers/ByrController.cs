using DesktopWarrior.DAL;
using DesktopWarrior.DAL.Interfaces;
using DesktopWarrior.DAL.Repositories;
using DesktopWarrior.Models;
using DesktopWarrior.Models.ViewModels;
using DesktopWarrior.Models.ViewModels.BuildYourRig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesktopWarrior.Controllers
{
    public class ByrController : Controller
    {
        private ICategoryRepository _categoryRep;
        private IProductRepository _productRep;

        public ByrController()
        {
            var context = new DesktopGuysContext();
            _categoryRep = new CategoryRepository(context);
            _productRep = new ProductRepository(context);
        }

        // GET: Byr
        public ActionResult Index(Byr byr, int id = 0)
        {
            return View(CreateByrViewModel(byr, id));
        }

        // TODO: Redirect back or next page?
        [HttpPost]
        public ActionResult AddToBuild(Byr byr, int productId, int id)
        {
            var product = _productRep.GetProductById(productId);
            var existProduct = byr.Lines.Where(x => x.Product.ProductId == productId).FirstOrDefault();

            if (existProduct == null)
            {
                byr.AddItem(product, 1);
            } else
            {
                var sameCat = existProduct.Product.CategoryId == id;
                if (!sameCat)
                {
                    byr.AddItem(product, 1);
                } else
                {
                    var line = byr.Lines.Where(p => p.Product.CategoryId == product.CategoryId).FirstOrDefault();

                    byr.Lines.Remove(line);
                    byr.AddItem(product, 1);
                }
            }
            return View("Index", CreateByrViewModel(byr, id));

        }


        private ByrViewModel CreateByrViewModel (Byr byr, int catId = 0)
        {
            var categories = _categoryRep.GetCategories();
            var category = categories.Find(x => x.CategoryId == (catId == 0 ? 1 : catId));
            var model = new ByrViewModel() { Categories = categories, Category = category, Build = byr };

            return model;
        }
    }
}