using DesktopWarrior.DAL;
using System.Collections.Generic;

namespace DesktopWarrior.Models.ViewModels
{
    public class CreateProductViewModel
    {
        public Product Product { get; set; }
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
    }
}