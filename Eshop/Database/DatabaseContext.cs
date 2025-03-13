using Eshop.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Database
{

	public class DatabaseContext : DbContext
	{
		public DbSet<Account> Accounts { get; set; }
		public DbSet<AccountType> AccountTypes { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Manufacturer> Manufacturers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<OrderState> OrderStates { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<Review> Reviews { get; set; }

	   public DatabaseContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<ProductCategory>()
				.HasOne(a => a.Product)
				.WithMany(b => b.ProductCategories)
				.HasForeignKey(c => c.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(a => a.Category)
                .WithMany(b => b.ProductCategories)
                .HasForeignKey(c => c.CategoryId);


        }
    }

}
