using System.ComponentModel.DataAnnotations;
using BrazilianTypes.Interfaces;
using BrazilianTypes.Types;

namespace BrazilianTypes.Annotations;

/// <summary>Cpf data annotation</summary>
public class CpfAttribute : ValidationAttribute, IValidationError
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
            return new ValidationResult(Cpf.ErrorMessage);
        }

        var cpf = value.ToString() ?? string.Empty;

        return !Cpf.TryParse(cpf, out _)
            ? new ValidationResult(Cpf.ErrorMessage)
            : ValidationResult.Success;
    }
}
