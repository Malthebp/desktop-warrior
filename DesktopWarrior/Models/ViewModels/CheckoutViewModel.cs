using DesktopWarrior.Models.ViewModels.BuildYourRig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace DesktopWarrior.Models.ViewModels
{
    public class CheckoutViewModel
    {
        public List<Category> Categories { get; set; }
        public Checkout Checkout { get; set; }
        public Byr Build { get; set; }
        public List<SelectListItem> PaymentMethods { get; set; }
    }
}