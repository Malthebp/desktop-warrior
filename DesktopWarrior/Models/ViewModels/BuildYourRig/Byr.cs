using DesktopWarrior.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesktopWarrior.Models.ViewModels.BuildYourRig
{
    public class Byr
    {
        private List<ByrLine> lines = new List<ByrLine>();
        public decimal TotalPrice
        {
            get { return lines.Sum(e => e.Product.Price * e.Quantity); }
        }
        public List<ByrLine> Lines { get { return lines; } }


        public Byr()
        { }

        public void AddItem(Product product, int quantity)
        {
            ByrLine item = lines.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();
            if (item == null)
            {
                this.lines.Add(new ByrLine(product, quantity));
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void RemoveItem(Product product)
        {
            var item = this.lines.SingleOrDefault(x => x.Product.ProductId == product.ProductId);
            this.lines.Remove(item);
        }

        public void Clear()
        {
            this.lines.Clear();
        }
    }
}