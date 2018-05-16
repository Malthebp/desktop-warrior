using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesktopWarrior.Models.ViewModels
{
    public class ByrViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}