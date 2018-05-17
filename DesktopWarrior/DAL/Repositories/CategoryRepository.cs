using DesktopWarrior.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using DesktopWarrior.Models;

namespace DesktopWarrior.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository, IDisposable
    {
        private readonly DesktopGuysContext context;
        public CategoryRepository(DesktopGuysContext context)
        {
            this.context = context;
        }

        public Category GetCategoryById(int productId)
        {
            return context.Categories.Find(productId);
        }

        public List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }

        public List<Category> GetCategoriesBySql()
        {
            return context.Categories.SqlQuery(@"SELECT p.*, pt.* FROM dg_Products p INNER JOIN dg_ProductsTypes as pt ON pt.ProductId = p.ProductId WHERE p.CategoryId = 4 AND pt.TypeId = 17").ToList();
        }


        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}