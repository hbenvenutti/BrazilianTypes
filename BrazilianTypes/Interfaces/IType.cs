namespace BrazilianTypes.Interfaces;

/// <summary>
/// Represents a generic type with parsing capabilities.
/// </summary>
/// <typeparam name="T">The type to be represented.</typeparam>
public interface IType<T> where T : struct
{
    /// <summary>
    /// Gets the error message associated with parsing failures.
    /// </summary>

    static abstract string ErrorMessage { get; }

    /// <summary>
    /// Attempts to parse a string value into the specified type.
    /// </summary>
    /// <param name="value">The string value to be parsed.</param>
    /// <param name="parsedValue">When this method returns, contains the parsed value
    /// if successful; otherwise, the default value.</param>
    /// <returns><c>true</c> if parsing was successful; otherwise, <c>false</c>.
    /// </returns>

    static abstract bool TryParse(string value, out T parsedValue);
}
