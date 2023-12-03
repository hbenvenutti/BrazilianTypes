namespace BrazilianTypes.Interfaces;

/// <summary>Interface to add error code to data annotations.</summary>
public interface IValidationError
{
    int ErrorCode { get; }
}
