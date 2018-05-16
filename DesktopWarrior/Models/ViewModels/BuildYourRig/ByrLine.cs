using DesktopWarrior.DAL;

namespace DesktopWarrior.Models.ViewModels.BuildYourRig
{
    public class ByrLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public ByrLine(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }
    }
}