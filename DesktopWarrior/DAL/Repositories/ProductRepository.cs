using DesktopWarrior.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DesktopWarrior.Models;
using System.Data.SqlClient;

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

        public List<Product> GetCompatibleProducts(int catId, int[] typeIds)
        {
            if(typeIds.Length > 0) {
                var joinedInts = string.Join(",", typeIds.Select(x => x.ToString()).ToArray());
                var sql1 = new SqlParameter("@CategoryID", catId);
                var sql2 = new SqlParameter("@ChildIDs", joinedInts);

                var products = context.Products.SqlQuery("exec getProducts @CategoryID, @ChildIDs", sql1, sql2).ToList();
                return products;
            } else
            {
                return new List<Product>();
            }
        }

        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return context.Products.Where(x => x.CategoryId == categoryId).ToList();
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

        public void AttachTypeToProduct(int typeId, int productId)
        {

            var product = new Product() { ProductId = productId };
            context.Products.Add(product);
            context.Products.Attach(product);

            var type = new Models.Type() { TypeId = typeId };
            context.Types.Add(type);
            context.Types.Attach(type);

            product.Types = new List<Models.Type>();
            product.Types.Add(type);

            Save();
        }

        public void DetachTypeFromProduct(int typeId, int productId)
        {
            var product = context.Products.Include(x => x.Types).Single(x => x.ProductId == productId);

            context.Products.Attach(product);
            var typeToDelet = product.Types.First(x => x.TypeId == typeId);
            if (typeToDelet != null)
            {
                product.Types.Remove(typeToDelet);
                Save();
            }
        }
    }
}