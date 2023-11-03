namespace BrazilianTypes.Interfaces;

/// <summary>
/// Represents a generic type with generation capabilities.
/// </summary>
/// <typeparam name="T">The type to be generated.</typeparam>
public interface IGenerable<out T> where T : struct
{
    /// <summary>
    /// Generates an instance of the specified type.
    /// </summary>
    /// <returns>An instance of the specified type.</returns>
    static abstract T Generate();
}
