using DesktopWarrior.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DesktopWarrior.Models;
using DesktopWarrior.DAL.Contexts;
using System.Data.Entity;

namespace DesktopWarrior.DAL.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private readonly DesktopGuysContext context;
        public ProductRepository(DesktopGuysContext context)
        {
            this.context = context;
        }

        public void DeleteProduct(int productId)
        {
            var product = context.Products.Find(productId);
            context.Products.Remove(product);
        }

        public Product GetProductById(int productId)
        {
            return context.Products.Find(productId);
        }

        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            context.Products.Add(product);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
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