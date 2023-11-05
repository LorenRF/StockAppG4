using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) 
        {
            
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent API
            #region tables
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Category>().ToTable("Categories");
            #endregion

            #region "Primary keys"
            modelBuilder.Entity<Product>().HasKey(product  => product.Id); //Llamada
            modelBuilder.Entity<Category>().HasKey(Category => Category.Id); //Llamada
            #endregion

            #region relationships
            modelBuilder.Entity<Category>().HasMany<Product>(Category => Category.Products)
                .WithOne(Product => Product.Category)
                .HasForeignKey(Product => Product.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Products
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Product>().Property(p => p.price).IsRequired();
            #endregion

            #region Category
            modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(150);


            #endregion
        }
    }
}
