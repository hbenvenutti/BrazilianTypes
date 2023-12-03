using System.ComponentModel.DataAnnotations;
using BrazilianTypes.Types;

namespace BrazilianTypes.Annotations;

/// <summary>ZipCode data annotation</summary>
public class ZipCodeAttribute : ValidationAttribute
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
            return new ValidationResult(ZipCode.ErrorMessage);
        }

        var zipCode = value.ToString() ?? string.Empty;

        return !ZipCode.TryParse(zipCode, out _)
            ? new ValidationResult(ZipCode.ErrorMessage)
            : ValidationResult.Success;
    }
}
