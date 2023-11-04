using BrazilianTypes.Extensions;
using BrazilianTypes.Interfaces;
using BrazilianTypes.Structs;

namespace BrazilianTypes.Types;

/// <summary>
/// Name
/// Represents a text that has only letters and cannot be null or empty.
/// <para>Validates and formats a string value.</para>
/// <para>Validates if the text is not null, empty or whitespace.</para>
/// <para>Validates if the text has only letters.</para>
/// <para>Formats the text by trimming it.</para>
/// </summary>
public readonly struct Name : IType<Name>
{
    # region ---- properties ---------------------------------------------------

    /// <summary>
    /// Gets the error message associated with invalid name values.
    /// </summary>
    public static string ErrorMessage =>
        "Name must have only letters and cannot be empty.";

    private readonly string _value;

    # endregion

    # region ---- constructor --------------------------------------------------

    private Name(string value)
    {
        _value = value;
    }

    # endregion

    # region ---- parse --------------------------------------------------------

    private static Name Parse(string value)
    {
        if (!TryParse(value, out var name))
        {
            throw new ArgumentException(
                message: ErrorMessage,
                paramName: nameof(value)
            );
        }

        return name;
    }

    /// <summary>
    /// Tries to parse a string value into a <see cref="Name"/>.
    /// </summary>
    /// <param name="value">String to be converted</param>
    /// <param name="name">The resulting <see cref="Name"/> object if the
    /// conversion is successful</param>
    /// <returns>True if the conversion is successful; otherwise, False.
    /// </returns>
    public static bool TryParse(string value, out Name name)
    {
        if (!IsValid(value))
        {
            name = default;
            return false;
        }

        name = new Name(value.Trim());

        return true;
    }

    # endregion

    # region ---- validation ---------------------------------------------------

    private static bool IsValid(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) { return false; }

        value = RegexPatterns.RemoveWhiteSpace(value);

        if (value.Length < 2) { return false; }

        if (!value.IsAlphabetic()) { return false; }

        return true;
    }

    # endregion

    # region ---- operators ----------------------------------------------------

    /// <summary>
    /// Converts a string value into a <see cref="Name"/> object.
    /// </summary>
    /// <param name="value">The string to be converted.</param>
    /// <returns>The resulting <see cref="Name"/>.</returns>
    public static implicit operator Name(string value) => Parse(value);

    /// <summary>
    /// Converts a <see cref="Name"/> into a string value.
    /// </summary>
    /// <param name="name">The <see cref="Name"/> to be converted.</param>
    /// <returns>The resulting string.</returns>
    public static implicit operator string(Name name) => name._value;

    # endregion
}
