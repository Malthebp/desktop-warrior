namespace DesktopWarrior.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DesktopGuysContext : DbContext
    {
        public DesktopGuysContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Specification> Specifications { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Types)
                .WithMany(e => e.Categories)
                .Map(m => m.ToTable("dg_CategoriesTypes").MapLeftKey("CategoryId").MapRightKey("TypeId"));

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Types)
                .WithMany(e => e.Products)
                .Map(m => m.ToTable("dg_ProductsTypes").MapLeftKey("ProductId").MapRightKey("TypeId"));

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Types1)
                .WithOptional(e => e.Types2)
                .HasForeignKey(e => e.ParentId);
        }
    }
}
