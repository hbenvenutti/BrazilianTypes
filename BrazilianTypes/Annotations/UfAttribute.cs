using System.ComponentModel.DataAnnotations;
using BrazilianTypes.Types;

namespace BrazilianTypes.Annotations;

/// <summary>Data annotation for Uf</summary>
public class UfAttribute: ValidationAttribute
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
            return new ValidationResult(Uf.ErrorMessage);
        }

        var uf = value.ToString() ?? string.Empty;

        return !Uf.TryParse(uf, out _)
            ? new ValidationResult(Uf.ErrorMessage)
            : ValidationResult.Success;
    }
}
