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
        [HttpGet]
        public RedirectToRouteResult AddToBuild(Byr byr, int productId, int catId, string returnUrl)
        {
            var product = _productRep.GetProductById(productId);
            var existProduct = byr.Lines.Where(x => x.Product.ProductId == productId).FirstOrDefault();

            if (existProduct == null)
            {
                byr.AddItem(product, 1);
            } else
            {
                var sameCat = existProduct.Product.CategoryId == catId;
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
            var id = catId;
            
            return RedirectToAction("Index", new { controller = returnUrl.Substring(1) });
        }


        private ByrViewModel CreateByrViewModel (Byr byr, int catId = 0)
        {
            catId = catId == 0 ? 1 : catId;

            var categories = _categoryRep.GetCategories();
            var category = categories.Find(x => x.CategoryId == catId);
            var ids = new Product().GetCompatibleIds(catId, byr, categories);

            var compProducts = _productRep.GetCompatibleProducts(catId, new int[] { 17 });

            var model = new ByrViewModel() { Categories = categories, Category = category, Build = byr, CompatibleProducts = compProducts };

            return model;
        }
    }
}