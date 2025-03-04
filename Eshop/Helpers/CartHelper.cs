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
				outList.Add(new(prod, pair.Value));
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
