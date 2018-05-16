using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesktopWarrior.Models.ViewModels
{
    public class ByrViewModel
    {
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
    }
}