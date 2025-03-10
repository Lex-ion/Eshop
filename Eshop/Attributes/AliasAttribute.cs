namespace Eshop.Attributes
{

	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class AliasAttribute: Attribute
	{
       public string Alias { get; set; }

		public AliasAttribute(string alias)
		{
			Alias = alias;
		}
	}

   
}
