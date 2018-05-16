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
    public class CategoryRepository : ICategoryRepository, IDisposable
    {
        private readonly WebshopContext context;
        public CategoryRepository(WebshopContext context)
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