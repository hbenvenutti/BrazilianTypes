using System.ComponentModel.DataAnnotations;
using BrazilianTypes.Types;

namespace BrazilianTypes.Annotations;

/// <summary>Name data annotation</summary>
public class NameAttribute : ValidationAttribute
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
            return new ValidationResult(Name.ErrorMessage);
        }

        var name = value.ToString() ?? string.Empty;

        return !Name.TryParse(name, out _)
            ? new ValidationResult(Name.ErrorMessage)
            : ValidationResult.Success;
    }
}
