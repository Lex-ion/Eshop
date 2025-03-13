using System.ComponentModel.DataAnnotations;

namespace Eshop.Attributes
{
    public class IsLessThanAttribute:ValidationAttribute
    {
		private readonly string _otherProperty;

		public IsLessThanAttribute(string otherProperty)
		{
			_otherProperty = otherProperty;
		}

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			if (value is null) return ValidationResult.Success;

			var otherProperty = validationContext.ObjectType.GetProperty(_otherProperty);
			if (otherProperty == null)
			{
				return new ValidationResult($"Property '{_otherProperty}' not found.");
			}

			var otherValue = otherProperty.GetValue(validationContext.ObjectInstance);
			if (otherValue is null) return ValidationResult.Success;

			if (value is not IComparable comparableValue)
			{
				return new ValidationResult($"Property '{validationContext.MemberName}' is not comparable.");
			}

			if (otherValue is not IComparable comparableOtherValue)
			{
				return new ValidationResult($"Property '{_otherProperty}' is not comparable.");
			}

			if (comparableValue.CompareTo(comparableOtherValue) >= 0)
			{
				return new ValidationResult($"Hodnota pole '{validationContext.MemberName}' musí být menší než '{_otherProperty}'.");
			}

			return ValidationResult.Success;
		}
	}
}
