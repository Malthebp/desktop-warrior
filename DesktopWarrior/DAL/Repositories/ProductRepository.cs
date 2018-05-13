using DesktopWarrior.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DesktopWarrior.Models;
using DesktopWarrior.DAL.Contexts;

namespace DesktopWarrior.DAL.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private readonly TESTContext context;
        public ProductRepository(TESTContext context)
        {
            this.context = context;
        }

        public void DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int productId)
        {
            return context.Products.Find(x => x.ProductId == productId);
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public void InsertProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }


        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if(disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose ()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}