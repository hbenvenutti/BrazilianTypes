using System.ComponentModel.DataAnnotations;
using BrazilianTypes.Types;

namespace BrazilianTypes.Annotations;

/// <summary>Text data annotation</summary>
public class TextAttribute : ValidationAttribute
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
            return new ValidationResult(Text.ErrorMessage);
        }

        var text = value.ToString() ?? string.Empty;

        return !Text.TryParse(text, out _)
            ? new ValidationResult(Text.ErrorMessage)
            : ValidationResult.Success;
    }
}
