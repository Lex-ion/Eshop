﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Entities
{
	[Table("tbProducts")]
	public class Product
	{

		[Column("ID")]
		public int Id { get; set; }

		[Column("NAME")]
		public string Name { get; set; }

		[Column("Description")]
		public string? Description { get; set; }

		[Column("Price")]
		public decimal Price { get; set; }

		[Column("Discount")]
		public decimal? Discount { get; set; }

		[Column("AvailableCount")]
		public int? AvailableCount { get; set; }

		[Column ("ManufacturerID")]
		public int ManufacturerID { get; set; }
		public virtual Manufacturer Manufacturer { get; set; }

		public virtual List<ProductCategory> ProductCategories { get; set; }

		public virtual List<Review> ProductReviews { get; set; }

		public Product(int id, string name, string? description, decimal price, decimal? discount, int? availableCount, int manufacturerID, Manufacturer manufacturer, List<ProductCategory> productCategories, List<Review> productReviews)
		{
			Id = id;
			Name = name;
			Description = description;
			Price = price;
			Discount = discount;
			AvailableCount = availableCount;
			ManufacturerID = manufacturerID;
			Manufacturer = manufacturer;
			ProductCategories = productCategories;
			ProductReviews = productReviews;
		}

		public Product()
		{
			Id = 0;
			Name = string.Empty;
			Description = null;
			Price = 0;
			Discount = null;
			AvailableCount = null;
			ManufacturerID = 0;
			Manufacturer = null!;
			ProductCategories = [];
			ProductReviews = [];
		}
		public override string? ToString()
		{
			return Name;
		}
	}
}
