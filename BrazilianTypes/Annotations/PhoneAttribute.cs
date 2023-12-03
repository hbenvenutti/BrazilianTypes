using System.ComponentModel.DataAnnotations;
using BrazilianTypes.Interfaces;
using BrazilianTypes.Types;

namespace BrazilianTypes.Annotations;

/// <summary>Phone data annotation</summary>
public class PhoneAttribute : ValidationAttribute, IValidationError
{
    /// <summary>Api error code</summary>
    public int ErrorCode { get; set; } = 400;

    /// <summary></summary>
    protected override ValidationResult? IsValid(
        object? value,
        ValidationContext validationContext
    )
    {
        if (value == null)
        {
            return new ValidationResult(Phone.ErrorMessage);
        }

        var name = value.ToString() ?? string.Empty;

        return !Phone.TryParse(name, out _)
            ? new ValidationResult(Phone.ErrorMessage)
            : ValidationResult.Success;
    }

}
