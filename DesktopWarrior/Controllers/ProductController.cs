using DesktopWarrior.DAL;
using DesktopWarrior.DAL.Interfaces;
using DesktopWarrior.DAL.Repositories;
using DesktopWarrior.Models;
using DesktopWarrior.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace DesktopWarrior.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        private ICategoryRepository _categoryRep;
        private readonly string _authProductViewPath = "~/Views/Authentication/Product/";

        public ProductController()
        {
            _repository = new ProductRepository(new DesktopGuysContext());
            _categoryRep = new CategoryRepository(new DesktopGuysContext());
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        // GET: Authenticated Products
        public ActionResult AuthProductIndex(int categoryId = 0, string productType = null)
        {
            var categories = _categoryRep.GetCategories();
            if (productType == null)
            {
                return View(_authProductViewPath + "Index.cshtml", categories);
            }
            else
            {
                var products = _repository.GetProductsByCategory(categoryId);
                var category = _categoryRep.GetCategoryById(categoryId);
                return View(_authProductViewPath + "List.cshtml", new ListProductViewModel() { Products = products, Category = category });

            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create(string productType = null)
        {
            var categories = _categoryRep.GetCategories();

            if (productType == null)
            {
                return View(_authProductViewPath + "Create.cshtml", categories);
            }
            else
            {
                var category = categories.Find(x => x.UrlFriendlyTitle == productType);

                return View(_authProductViewPath + "CreateForm.cshtml", new CreateProductViewModel() { Category = category, Categories = categories, Product = new Product() });
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Product product)
        {
            _repository.InsertProduct(product);
            _repository.Save();
            return RedirectToAction("Update", "Product", new { productId = product.ProductId });
        }

        [Authorize]
        [HttpGet]
        public ActionResult Update(int productId)
        {
            var product = _repository.GetProductById(productId);
            var categories = _categoryRep.GetCategories();
            var category = _categoryRep.GetCategoryById(Convert.ToInt16(product.CategoryId));
            return View(_authProductViewPath + "update.cshtml", new UpdateProductViewModel() { Category = category, Categories = categories, Product = product, Types = category.Types });

        }

        [Authorize]
        [HttpPost]
        public RedirectToRouteResult Update(Product product)
        {
            _repository.UpdateProduct(product);
            _repository.Save();
            var categories = _categoryRep.GetCategories();
            var category = _categoryRep.GetCategoryById(Convert.ToInt16(product.CategoryId));

            return RedirectToAction("Update", "Product", new { productId = product.ProductId });
        }

        [Authorize]
        [HttpPost]
        public ActionResult List()
        {

            var products = _repository.GetProducts();
            return View(_authProductViewPath + "List.cshtml", products);
        }

        [Authorize]
        public PartialViewResult GetFormType(string type, Product product)
        {
            return PartialView(_authProductViewPath + "Forms/" + type + ".cshtml", product);
        }
        
        [Authorize]
        [HttpPost]
        public RedirectToRouteResult SelectType(int typeId, int productId, int categoryId)
        {
            _repository.AttachTypeToProduct(typeId, productId);
            
            return RedirectToAction("Update", "Product", new { productId = productId });

        }

        [Authorize]
        [HttpPost]
        public RedirectToRouteResult RemoveType(int typeId, int productId, int categoryId)
        {
            _repository.DetachTypeFromProduct(typeId, productId);

            return RedirectToAction("Update", "Product", new { productId = productId });

        }
    }
}