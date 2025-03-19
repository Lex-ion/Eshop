using Eshop.Database;
using Eshop.Entities;
using Eshop.Models;
using System.Text.Json;

namespace Eshop.Helpers
{
	public class CartHelper
	{
		public static List<OrderItemModel> GetCart(HttpContext HttpContext,DatabaseContext dbContext)
		{
			Dictionary<int, int> cart = GetCartDictionary(HttpContext);
			List<OrderItemModel> outList = new();

			foreach (KeyValuePair<int,int> pair in cart)
			{
				Product prod = dbContext.Products.Single(p => p.Id == pair.Key);
				int count = Math.Clamp(pair.Value, 0, prod.AvailableCount??0);
				if (count < 1)
					continue;
				outList.Add(new(prod, count,prod.AvailableCount??0));
			}

			return outList;
		}
		public static void AddToCart(HttpContext context, OrderItemModel model)
		{
			Dictionary<int, int> cart = GetCartDictionary(context);

			if (!cart.TryAdd(model.ProductId, model.Count))
			{
				cart[model.ProductId] += model.Count;
			}

			context.Session.SetString("CartJSON", JsonSerializer.Serialize(cart));
		}

		public static void RemoveFromCart(HttpContext context, int productId)
		{
			var cart = GetCartDictionary(context);

			cart.Remove(productId);

			context.Session.SetString("CartJSON", JsonSerializer.Serialize(cart));
		}
		public static void UpdateInCart(HttpContext context, int productId,int newValue)
		{
			var cart = GetCartDictionary(context);

			if (!cart.TryAdd(productId, newValue))
			{
				cart[productId] = newValue;
			}

			context.Session.SetString("CartJSON", JsonSerializer.Serialize(cart));
		}

		private static Dictionary<int,int> GetCartDictionary(HttpContext context)
		{
			Dictionary<int, int> cart;
			string? cartJson = context.Session.GetString("CartJSON");
			if (cartJson is null)
				cart = new();
			else cart = JsonSerializer.Deserialize<Dictionary<int, int>>(cartJson)!;

			return cart;
		}
	}
}
