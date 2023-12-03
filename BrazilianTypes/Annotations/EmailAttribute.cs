using System.ComponentModel.DataAnnotations;
using BrazilianTypes.Interfaces;
using BrazilianTypes.Types;

namespace BrazilianTypes.Annotations;

/// <summary>Email data annotation</summary>
public class EmailAttribute : ValidationAttribute, IValidationError
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
            return new ValidationResult(Email.ErrorMessage);
        }

        var email = value.ToString() ?? string.Empty;

        return !Email.TryParse(email, out _)
            ? new ValidationResult(Email.ErrorMessage)
            : ValidationResult.Success;
    }
}
