using DesktopWarrior.DAL.Interfaces;
using DesktopWarrior.DAL.Repositories;
using DesktopWarrior.Models;
using DesktopWarrior.Models.ViewModels;
using DesktopWarrior.Models.ViewModels.BuildYourRig;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DesktopWarrior.Controllers
{
    public class CheckoutController : Controller
    {
        private ICategoryRepository _catRepository;
        public CheckoutController()
        {
            _catRepository = new CategoryRepository(new DAL.DesktopGuysContext());
        }

        // GET: Checkout
        public ActionResult Index(Byr byr)
        {
            var model = new CheckoutViewModel()
            {
                Categories = _catRepository.GetCategories(),
                Build = byr,
                Checkout = new Checkout(),
                PaymentMethods = new List<SelectListItem> ()
                {
                    new SelectListItem() {Text = "PayPal", Value = "PayPal", Selected = false},
                    new SelectListItem() {Text = "Carrier pigeon", Value = "Carrier", Selected = false},
                    new SelectListItem() {Text = "Credit card / Debit card", Value = "Credit", Selected = true},
                }
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Payment(Byr byr, Checkout checkout)
        {
            if (checkout.FirstName != null)
            { 
                var model = new CheckoutViewModel()
                {
                    Categories = _catRepository.GetCategories(),
                    Build = byr,
                    Checkout = checkout
                };
                return View(model);
            } else
            {
                return View("Index");
            }
        }

        public PartialViewResult PartialBuildOverview(CheckoutViewModel obj)
        {

            return PartialView("~/Views/Checkout/BuildOverview.cshtml", obj);
        }
    }
}