using DesktopWarrior.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DesktopWarrior.Models;
using System.Data.SqlClient;

namespace DesktopWarrior.DAL.Repositories
{
    public class SpecificationRepository : ISpecificaitonRepository, IDisposable
    {
        private readonly DesktopGuysContext context;
        public SpecificationRepository(DesktopGuysContext context)
        {
            this.context = context;
        }

        public void DeleteSpecification(int specificationId)
        {
            Specification specification = new Specification() { SpecificationId = specificationId };
            context.Specifications.Attach(specification);
            context.Specifications.Remove(specification);
            context.SaveChanges();
        }

        public Specification GetSpecificationById(int specificationId)
        {
            return context.Specifications.Find(specificationId);
        }

        public List<Specification> GetSpecifications()
        {
            return context.Specifications.ToList();
        }

        public List<Specification> GetSpecificationsByProductId(int productId)
        {
            return context.Specifications.Where(x => x.ProductId == productId).ToList();
        }


        public void InsertSpecification(Specification specification)
        {
            context.Specifications.Add(specification);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateSpecification(Specification specification)
        {
            context.Entry(specification).State = EntityState.Modified;
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