using Eshop.Attributes;
using Eshop.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.Models
{
	public class ProductFormModel
	{
		public int Id { get; set; }
		[MaxLength(50)]
		public string Name { get; set; }

		[MaxLength(5000)]
		public string? Description { get; set; }
		[MaxValue(99999999.99)]
		public decimal Price { get; set; }

		[IsLessThan("Price")]
		public decimal? Discount { get; set; }

		public int? AvailableCount { get; set; }

		public int ManufacturerID { get; set; }

		[ValidateNever]
		public List<Manufacturer> Manufacturers { get; set; }

		public ProductFormModel(int id, string name, string? description, decimal price, decimal? discount, int? availableCount, int manufacturerID, List<Manufacturer> manufacturers)
		{
			Id = id;
			Name = name;
			Description = description;
			Price = price;
			Discount = discount;
			AvailableCount = availableCount;
			ManufacturerID = manufacturerID;
			Manufacturers = manufacturers;
		}

		public ProductFormModel()
		{
			Id = 0;
			Name = string.Empty;
			Description = null;
			Price = 0;
			Discount = null;
			AvailableCount = null;
			ManufacturerID = 0;
			Manufacturers = [];
		}
	}
}
