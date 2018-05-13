using DesktopWarrior.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesktopWarrior.DAL.Interfaces
{
    public interface IProductRepository : IDisposable
    {

        List<Product> GetProducts();
        Product GetProductById(int productId);
        void InsertProduct(Product product);
        void DeleteProduct(int productId);
        void UpdateProduct(Product product);
        void Save();
    }
}