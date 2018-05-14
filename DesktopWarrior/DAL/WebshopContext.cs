using DesktopWarrior.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DesktopWarrior.DAL
{
    public class WebshopContext : DbContext
    {
        public WebshopContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Specification> Specifications { get; set; }
        public virtual DbSet<Models.Type> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(10, 5);

            modelBuilder.Entity<Models.Type>()
                .HasMany(e => e.dg_Types1)
                .WithOptional(e => e.dg_Types2)
                .HasForeignKey(e => e.ParentId);
        }
    }
}