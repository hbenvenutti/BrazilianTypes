using BrazilianTypes.Interfaces;
using BrazilianTypes.Services;

namespace BrazilianTypes.Types;

/// <summary>
/// Represents a brazilian CEP (Código de Endereçamento Postal).
/// </summary>

public readonly struct ZipCode : IType<ZipCode>, IMaskedType, IGenerable<ZipCode>
{
    # region ---- constants ----------------------------------------------------

    /// <inheritdoc/>

    public static string ErrorMessage => "Zip code is invalid.";

    # endregion

    private readonly string _value;

    /// <summary>
    /// Gets the zip code with a masking pattern applied.
    /// </summary>

    public string Mask => RegexService.MaskZipCode(_value);

    # region ---- constructor --------------------------------------------------

    private ZipCode(string value)
    {
        _value = value;
    }

    # endregion

    # region ---- parse --------------------------------------------------------

    private static ZipCode Parse(string value)
    {
        if (!TryParse(value, out var zipCode))
        {
            throw new ArgumentException(
                message: ErrorMessage,
                paramName: nameof(value)
            );
        }

        return zipCode;
    }

    /// <inheritdoc/>

    public static bool TryParse(string value, out ZipCode parsedValue)
    {
        value = RegexService
            .GetOnlyNumbers(value);

        if (!IsValid(value))
        {
            parsedValue = default;

            return false;
        }

        parsedValue = new ZipCode(value);

        return true;
    }

    # endregion

    # region ---- validation ---------------------------------------------------

    private static bool IsValid(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return false;

        return value.Length == 8;
    }

    # endregion

    # region ---- generation ---------------------------------------------------

    /// <summary>
    /// Generates a random ZipCode.
    /// </summary>
    /// <returns>A randomly generated ZipCode.</returns>
    public static ZipCode Generate()
    {
        var random = new Random();

        var zipCode = new byte[8];

        for (var i = 0; i < zipCode.Length; i++)
        {
            zipCode[i] = (byte)random.Next(10);
        }

        return string.Join("", zipCode);
    }

    # endregion

    # region ---- operators ----------------------------------------------------

    /// <summary>
    /// Converts a string to a <see cref="ZipCode"/>.
    /// </summary>
    /// <param name="value">The string representing the <see cref="ZipCode"/>.
    /// </param>
    /// <returns>The resulting <see cref="ZipCode"/>.</returns>
    public static implicit operator ZipCode(string value) => Parse(value);

    /// <summary>
    /// Converts a <see cref="ZipCode"/> to a string.
    /// </summary>
    /// <param name="zipCode">The <see cref="ZipCode"/> to be converted.</param>
    /// <returns>The resulting string.</returns>
    public static implicit operator string(ZipCode zipCode) => zipCode._value;

    # endregion
}
