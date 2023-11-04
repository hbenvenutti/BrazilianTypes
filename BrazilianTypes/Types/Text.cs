using BrazilianTypes.Interfaces;

namespace BrazilianTypes.Types;

/// <summary>
/// Text
/// Represents a text value that cannot be null or empty.
/// <para>Validates and formats a string value.</para>
/// <para>Validates if the text is not null, empty or whitespace.</para>
/// <para>Formats the text by trimming it.</para>
/// </summary>
public readonly struct Text : IType<Text>
{
    /// <summary>
    /// Gets the error message associated with invalid text values.
    /// </summary>
    public static string ErrorMessage => "Text cannot be empty.";

    private readonly string _value;

    # region ---- constructors -------------------------------------------------

    private Text(string value)
    {
        _value = value;
    }

    # endregion

    # region ---- parse --------------------------------------------------------

    /// <summary>
    /// Tries to parse a string value into a <see cref="Text"/>.
    /// </summary>
    /// <param name="value">String to be converted</param>
    /// <param name="text">The resulting <see cref="Text"/> object if the
    /// conversion is successful</param>
    /// <returns>True if the conversion is successful; otherwise, False.
    /// </returns>
    public static bool TryParse(string value, out Text text)
    {
        if (!IsValid(value))
        {
            text = default;

            return false;
        }

        text = new Text(value.Trim());

        return true;
    }

    private static Text Parse(string value)
    {
        if (!TryParse(value, out var text))
        {
            throw new ArgumentException(
                message: ErrorMessage,
                paramName: nameof(value)
            );
        }

        return text;
    }

    # endregion

    # region ---- validation ---------------------------------------------------

    private static bool IsValid(string value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }

    # endregion

    # region ---- operators ----------------------------------------------------

    /// <summary>
    /// Converts a string value into a <see cref="Text"/>.
    /// </summary>
    /// <param name="value">The string to be converted.</param>
    /// <returns>The resulting <see cref="Text"/>.</returns>
    public static implicit operator Text(string value) => Parse(value);

    /// <summary>
    /// Converts a <see cref="Text"/> into a string value.
    /// </summary>
    /// <param name="text">The <see cref="Text"/> to be converted.</param>
    /// <returns>The resulting string.</returns>
    public static implicit operator string(Text text) => text._value;

    # endregion
}
