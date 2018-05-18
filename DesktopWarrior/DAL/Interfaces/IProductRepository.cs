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
        List<Product> GetProductsByCategory(int categoryId);
        Product GetProductById(int productId);
        List<Product> GetCompatibleProducts(int catId, int[] typeIds);
        void AttachTypeToProduct(int typeId, int productId);
        void DetachTypeFromProduct(int typeId, int productId);
        void InsertProduct(Product product);
        void DeleteProduct(int productId);
        void UpdateProduct(Product product);
        void Save();
    }
}