using System.ComponentModel.DataAnnotations;

namespace Eshop.Attributes
{
    public class MatchfieldsAttribute:ValidationAttribute
    {
        private readonly string _otherProperty;

        public MatchfieldsAttribute(string otherProperty)
        {
            _otherProperty = otherProperty;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var otherProperty = validationContext.ObjectType.GetProperty(_otherProperty);
            if (otherProperty == null)
            {
                throw new MissingFieldException($"Property '{_otherProperty}' not found.");
            }

            var otherValue = otherProperty.GetValue(validationContext.ObjectInstance, null);

            if (otherValue is null || !otherValue.Equals(value))
            {
                return new ValidationResult("Pole se neschodují.");
            }

            return ValidationResult.Success;
        }
    }
}
