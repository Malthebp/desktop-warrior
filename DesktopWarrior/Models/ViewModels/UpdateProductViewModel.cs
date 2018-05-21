using DesktopWarrior.DAL;
using System.Collections.Generic;

namespace DesktopWarrior.Models.ViewModels
{
    public class UpdateProductViewModel
    {
        public Specification Specification { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
        public ICollection<Type> Types { get; set; }
        public List<Specification> Specifications { get; set; }
    }
}