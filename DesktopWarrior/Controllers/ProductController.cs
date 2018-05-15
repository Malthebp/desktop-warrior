﻿using DesktopWarrior.DAL;
using DesktopWarrior.DAL.Interfaces;
using DesktopWarrior.DAL.Repositories;
using DesktopWarrior.Models;
using DesktopWarrior.Models.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace DesktopWarrior.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        private readonly string _authProductViewPath = "~/Views/Authentication/Product/";

        public ProductController()
        {
            _repository = new ProductRepository(new WebshopContext());
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        // GET: Authenticated Products
        public ActionResult AuthProductIndex()
        {
            return View(_authProductViewPath + "Index.cshtml");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create(string productType = null)
        {
            var categories = new List<Category>()
            {
                new Category() {Title = "CPU", CategoryId = 1, Description = "Something",
                    Types = new List<Type>()
                    {
                        new Type() {Title = "Some type title 1", TypeId = 1, CategoryId = 1, Description = "Type description"},
                        new Type() {Title = "Some type title 2", TypeId = 2, CategoryId = 2, Description = "Type description"},
                        new Type() {Title = "Some type title 3", TypeId = 3, CategoryId = 3, Description = "Type description"},
                    }
                },
                new Category() {Title = "Mother board", CategoryId = 2, Description = "Something",
                    Types = new List<Type>()
                    {
                        new Type() {Title = "Some type title 1", TypeId = 4, CategoryId = 1, Description = "Type description"},
                        new Type() {Title = "Some type title 2", TypeId = 5, CategoryId = 2, Description = "Type description"},
                    }
                },
                new Category() {Title = "Memory", CategoryId = 3, Description = "Something"}
            };

            if (productType == null)
            {
                return View(_authProductViewPath + "Create.cshtml", categories);
            } else
            {
                var category = categories.Find(x => x.UrlFriendlyTitle == productType);

                return View(_authProductViewPath + "CreateForm.cshtml", new CreateProductViewModel() { Category = category, Categories = categories, Product = new Product()});
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create (Product product)
        {
            _repository.InsertProduct(product);
            _repository.Save();
            return View(_authProductViewPath + "Index.cshtml");
        }

        [Authorize]
        public PartialViewResult GetFormType (string type, Product product)
        {
            return PartialView(_authProductViewPath + "Forms/" + type + ".cshtml", product);
        }
    }
}