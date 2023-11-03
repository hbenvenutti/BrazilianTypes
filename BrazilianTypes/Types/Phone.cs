using BrazilianTypes.Interfaces;
using BrazilianTypes.Structs;

namespace BrazilianTypes.Types;

/// <summary>
/// Represents a Brazilian phone number.
/// </summary>
public readonly struct Phone : IMaskedType
{
    # region ---- properties ---------------------------------------------------

    /// <summary>
    /// Gets the error message associated with invalid phone numbers.
    /// </summary>
    public const string ErrorMessage = "Invalid phone number";

    /// <summary>
    /// Gets the phone number with a masking pattern applied.
    /// </summary>
    public string Mask => RegexPatterns.MaskPhone(_value);

    /// <summary>
    /// Gets the phone number without area code.
    /// </summary>
    public string Number => _value[2..];

    /// <summary>
    /// Gets the area code (DDD) of the phone number.
    /// </summary>
    public string Ddd => _value[..2];

    /// <summary>
    /// Indicates if the phone number is a mobile number.
    /// </summary>
    public bool IsMobile => _value[2] == '9';

    private readonly string _value;

    # endregion

    # region ---- constructor --------------------------------------------------

    private Phone(string value)
    {
        _value = value;
    }

    # endregion

    # region ---- parse --------------------------------------------------------

    private static Phone Parse(string value)
    {
        if (!TryParse(value, out var phone))
        {
            throw new ArgumentException(
                message: ErrorMessage,
                paramName: nameof(value)
            );
        }

        return phone;
    }

    /// <summary>
    /// Attempts to convert a string into a <see cref="Phone"/> object.
    /// </summary>
    /// <param name="value">The string representing the phone number.</param>
    /// <param name="phone">The resulting <see cref="Phone"/> object if the
    /// conversion is successful.</param>
    /// <returns>True if the conversion is successful; otherwise, False.
    /// </returns>

    public static bool TryParse(string value, out Phone phone)
    {
        value = RegexPatterns
            .GetOnlyNumbers(value);

        if (!IsValid(value))
        {
            phone = default;

            return false;
        }

        phone = new Phone(value);

        return true;
    }

    # endregion

    # region ---- validation ---------------------------------------------------

    private static bool IsValid(string value)
    {
        switch (value.Length)
        {
            case < 10 or > 11:
            case 10 when value[2] != '3':
            case 11 when value[2] != '9':
                return false;
            default:
                return true;
        }
    }

    # endregion

    # region ---- factory ------------------------------------------------------

    /// <summary>
    /// Creates a <see cref="Phone"/> object from separate DDD and number strings.
    /// </summary>
    /// <param name="ddd">The area code (DDD).</param>
    /// <param name="number">The phone number.</param>
    /// <returns>A <see cref="Phone"/> object.</returns>
    public static Phone FromSplit(string ddd, string number) =>
        Parse($"{ddd}{number}");

    # endregion

    # region ---- operators ----------------------------------------------------

    /// <summary>
    /// Converts a string into a <see cref="Phone"/> object.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator Phone(string value) => Parse(value);

    /// <summary>
    /// Converts a <see cref="Phone"/> object into a string.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static implicit operator string(Phone type) => type._value;

    # endregion
}
