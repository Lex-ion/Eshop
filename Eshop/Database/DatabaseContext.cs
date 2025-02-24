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

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies();
			optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;database=4b2_urbantomas_db1;user=urbantomas;password=123456;charset=utf8;");
		}
	}

}
