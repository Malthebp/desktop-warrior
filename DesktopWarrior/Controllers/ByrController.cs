using DesktopWarrior.DAL;
using DesktopWarrior.DAL.Interfaces;
using DesktopWarrior.DAL.Repositories;
using DesktopWarrior.Models.ViewModels;
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
        
        public ByrController()
        {
            _categoryRep = new CategoryRepository(new DesktopGuysContext());
        }

        // GET: Byr
        public ActionResult Index()
        {
            var categories = _categoryRep.GetCategories();
            var category = categories.Find(x => x.CategoryId == 1);
            var viewModel = new ByrViewModel() { Categories = categories, Category = category };
            return View(viewModel);
        }
    }
}