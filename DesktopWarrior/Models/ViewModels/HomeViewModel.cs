using DesktopWarrior.DAL;
using System.Collections.Generic;

namespace DesktopWarrior.Models.ViewModels
{
    public class HomeViewModel
    {
        public Category Category { get; set; }
        public List<Product> Products { get; set; }
    }
}