﻿using DesktopWarrior.DAL;
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
            var lineProduct = byr.Lines.Where(p => p.Product.CategoryId == catId).FirstOrDefault();

            if(lineProduct == null || product.CategoryId != lineProduct.Product.CategoryId)
            {
                byr.AddItem(product, 1);
            } else
            {
                var sameCategoryProduct = byr.Lines.Where(p => p.Product.CategoryId == product.CategoryId).FirstOrDefault();
                byr.Lines.Remove(sameCategoryProduct);
                byr.AddItem(product, 1);
            }

            return RedirectToAction("Index", "Byr", new { id = catId, productId = product.ProductId });
        }

        [HttpGet]
        public RedirectToRouteResult removeFromBuild(Byr byr, int productId)
        {
            var product = _productRep.GetProductById(productId);
            byr.RemoveItem(product);
            var id = Url.RequestContext.RouteData.Values["id"];
            return RedirectToAction("Index", "Byr");
        } 


        private ByrViewModel CreateByrViewModel (Byr byr, int catId = 0)
        {
            catId = catId == 0 ? 1 : catId;

            var categories = _categoryRep.GetCategories();
            var category = categories.Find(x => x.CategoryId == catId);

            var ids = new Product().GetCompatibleIds(catId, byr);

            var compProducts = _productRep.GetCompatibleProducts(catId, ids.ToArray());
            var compatibleProducts = new List<Product>();

            foreach(var p in compProducts)
            {
                if (!compatibleProducts.Any(x => x.ProductId == p.ProductId))
                {
                    compatibleProducts.Add(p);
                }
            }

            var model = new ByrViewModel() { Categories = categories, Category = category, Build = byr, CompatibleProducts = compatibleProducts };

            return model;
        }
    }
}