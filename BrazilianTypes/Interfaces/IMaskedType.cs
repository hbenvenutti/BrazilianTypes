namespace BrazilianTypes.Interfaces;

/// <summary>
/// Represents a type with a masking feature.
/// </summary>
public interface IMaskedType
{
    /// <summary>
    /// Gets the string representation of the value with the applied mask.
    /// </summary>
    string Mask { get; }
}
