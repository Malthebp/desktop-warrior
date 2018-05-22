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
        public ActionResult Index(Byr byr, Checkout checkout)
        {
            var model = new CheckoutViewModel()
            {
                Categories = _catRepository.GetCategories(),
                Build = byr,
                Checkout = checkout,
                PaymentMethods = new List<SelectListItem> ()
                {
                    new SelectListItem() {Text = "PayPal", Value = "PayPal", Selected = false},
                    new SelectListItem() {Text = "Carrier pigeon", Value = "Carrier", Selected = false},
                    new SelectListItem() {Text = "Credit card / Debit card", Value = "Credit", Selected = true},
                },
                HasEditOptions = true
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Payment(Byr byr, Checkout checkout, FormCollection obj)
        {
            checkout.FirstName = obj["Checkout.FirstName"];
            checkout.LastName = obj["Checkout.LastName"];
            checkout.Email = obj["Checkout.Email"];
            checkout.Address = obj["Checkout.Address"];
            checkout.City = obj["Checkout.City"];
            checkout.Zip = Convert.ToInt16(obj["Checkout.Zip"]);
            checkout.Country = obj["Checkout.Country"];
            checkout.PaymentMethod = obj["Checkout.PaymentMethod"];

            var model = new CheckoutViewModel()
            {
                Categories = _catRepository.GetCategories(),
                Build = byr,
                Checkout = checkout,
                Payment = new Payment(),
                HasEditOptions = false
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Purchase (Byr byr, Checkout checkout, Payment payment = null)
        {
            var model = new CheckoutViewModel()
            {
                Build = byr,
                Checkout = checkout,
                Payment = payment,
                HasEditOptions = false
            };

            Session.Clear();
            return View("Completed", model);
        }

        public PartialViewResult PartialBuildOverview(CheckoutViewModel obj)
        {

            return PartialView("~/Views/Checkout/BuildOverview.cshtml", obj);
        }
    }
}