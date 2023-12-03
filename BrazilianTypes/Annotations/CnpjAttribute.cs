using System.ComponentModel.DataAnnotations;
using BrazilianTypes.Interfaces;
using BrazilianTypes.Types;

namespace BrazilianTypes.Annotations;

/// <summary>Cnpj data annotation</summary>
public class CnpjAttribute : ValidationAttribute, IValidationError
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
            return new ValidationResult(Cnpj.ErrorMessage);
        }

        var cnpj = value.ToString() ?? string.Empty;

        return !Cnpj.TryParse(cnpj, out _)
            ? new ValidationResult(Cnpj.ErrorMessage)
            : ValidationResult.Success;
    }
}
