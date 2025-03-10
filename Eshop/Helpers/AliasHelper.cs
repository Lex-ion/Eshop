using Eshop.Attributes;
using System.Reflection;

namespace Eshop.Helpers
{
	public static class AliasHelper
	{
		public static Dictionary<string, string> GetMethodAliases<T>()
		{
			return typeof(T)
				.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
				.Where(m => m.GetCustomAttribute<AliasAttribute>() != null)
				.ToDictionary(
					m => m.Name, // Název metody
					m => m.GetCustomAttribute<AliasAttribute>()!.Alias // Alias z atributu
				);
		}
	}
}
