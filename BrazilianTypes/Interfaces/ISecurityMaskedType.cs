namespace BrazilianTypes.Interfaces;

/// <summary>
/// Interface to add security mask to data annotations.
/// </summary>
public interface ISecurityMaskedType
{
    /// <summary>Gets the security mask.</summary>
    string SecurityMask { get; }
}
