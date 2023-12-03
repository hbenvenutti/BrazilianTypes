namespace BrazilianTypes.Interfaces;

/// <summary>Interface to add error code to data annotations.</summary>
public interface IValidationError
{
    /// <summary>Gets the error code.</summary>
    int ErrorCode { get; }
}
