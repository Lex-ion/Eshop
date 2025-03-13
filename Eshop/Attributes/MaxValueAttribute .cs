using System;
using System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class MaxValueAttribute : ValidationAttribute
{
	private readonly decimal _maxValue;

	public MaxValueAttribute(decimal maxValue)
	{
		_maxValue = maxValue;
	}
	public MaxValueAttribute(double maxValue)
	{
		_maxValue = (decimal)maxValue;
	}
	public MaxValueAttribute(int maxValue)
	{
		_maxValue = (decimal)maxValue;
	}
	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
	{
		if (value is null) return ValidationResult.Success; // Pokud je hodnota null, validace se neprovádí

		

		if ((decimal)value > _maxValue)
		{
			return new ValidationResult($"Hodnota pole '{validationContext.MemberName}' nesmí být větší než {_maxValue}.");
		}

		return ValidationResult.Success;
	}
}
