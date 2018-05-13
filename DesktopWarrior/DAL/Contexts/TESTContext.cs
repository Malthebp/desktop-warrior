using DesktopWarrior.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DesktopWarrior.DAL.Contexts
{
    public class TESTContext : DbContext
    {
        public List<Product> Products = new List<Product>();

        public TESTContext()
        {

            Products.Add(new Product { ProductId = 1, Title = "Product 1" });
            Products.Add(new Product { ProductId = 2, Title = "Product 2" });
        }
    }
}