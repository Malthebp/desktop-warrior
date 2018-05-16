using DesktopWarrior.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesktopWarrior.Models.ViewModels.BuildYourRig
{
    public class Bwr
    {
        private List<BwrLine> lines = new List<BwrLine>();
        public decimal TotalPrice
        {
            get { return lines.Sum(e => e.Product.Price * e.Quantity); }
        }
        public List<BwrLine> Lines { get { return lines; } }


        public Bwr()
        { }

        public void AddItem(Product product, int quantity)
        {
            BwrLine item = lines.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();
            if (item == null)
            {
                this.lines.Add(new BwrLine(product, quantity));
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