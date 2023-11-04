using System.Net.Mail;
using BrazilianTypes.Interfaces;

namespace BrazilianTypes.Types;

/// <summary>
/// Represents an email address.
/// </summary>
public readonly struct Email : IType<Email>
{
    # region ---- properties ---------------------------------------------------

    /// <inheritdoc />
    public static string ErrorMessage => "Invalid email address";

    private readonly string _value;

    # endregion

    # region ---- constructor --------------------------------------------------

    private Email(string value)
    {
        _value = value;
    }

    # endregion

    # region ---- parse --------------------------------------------------------

    /// <inheritdoc />
    public static bool TryParse(string value, out Email parsedValue)
    {
        parsedValue = default;

        if (string.IsNullOrWhiteSpace(value)) { return false; }

        value = value.Trim().ToLowerInvariant();

        if (!IsValid(value)) { return false; }

        parsedValue = new Email(value);
        return true;
    }

    private static Email Parse(string value)
    {
        if (!TryParse(value, out var email))
        {
            throw new ArgumentException(
                message: ErrorMessage,
                paramName: nameof(value)
            );
        }

        return email;
    }

    # endregion

    # region ---- validation ---------------------------------------------------

    private static bool IsValid(string value)
    {
        if (!MailAddress.TryCreate(address: value, out _))
        {
            return false;
        }

        var provider = value.Split(separator: '@')[1];

        if (provider.Contains(".."))
        {
            return false;
        }

        if (provider.Split(separator: '.').Length < 2)
        {
            return false;
        }

        if (provider.EndsWith("."))
        {
            return false;
        }

        return true;
    }

    # endregion

    # region ---- operators ----------------------------------------------------

    /// <summary>
    /// Converts a string into a <see cref="Email"/> object.
    /// </summary>
    /// <param name="value">The string representing the <see cref="Email"/>
    /// </param>
    /// <returns>The resulting <see cref="Email"/></returns>
    public static implicit operator Email(string value) => Parse(value);

    /// <summary>
    /// Converts a <see cref="Email"/> object into a string.
    /// </summary>
    /// <param name="email">The <see cref="Email"/> to be converted.</param>
    /// <returns>The resulting string.</returns>
    public static implicit operator string(Email email) => email._value;

    # endregion
}
