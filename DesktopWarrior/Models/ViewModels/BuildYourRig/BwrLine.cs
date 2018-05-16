using DesktopWarrior.DAL;

namespace DesktopWarrior.Models.ViewModels.BuildYourRig
{
    public class BwrLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public BwrLine(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }
    }
}