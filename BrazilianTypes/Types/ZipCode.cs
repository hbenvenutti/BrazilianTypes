using BrazilianTypes.Exceptions;
using BrazilianTypes.Interfaces;
using BrazilianTypes.Services;

namespace BrazilianTypes.Types;

/// <summary>
/// Represents a brazilian CEP (Código de Endereçamento Postal).
/// </summary>

public readonly struct ZipCode : IMaskedType
{
    # region ---- constants ----------------------------------------------------

    /// <summary>
    /// Mensagem de erro para CEPs inválidos.
    /// </summary>

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
            throw new InvalidValueException(
                message: ErrorMessage,
                value: value,
                paramName: nameof(value)
            );
        }

        return zipCode;
    }

    /// <summary>
    /// Tenta analisar uma string e retorna uma instância de <see cref="ZipCode"/>.
    /// </summary>
    /// <param name="value">A string a ser analisada.</param>
    /// <param name="zipCode">Quando este método retorna, contém o valor de <see cref="ZipCode"/>
    /// analisado, se a análise for bem-sucedida, ou o padrão se a análise falhar.
    /// </param>
    /// <returns><c>true</c> se a análise foi bem-sucedida; caso contrário, <c>false</c>.</returns>

    public static bool TryParse(string value, out ZipCode zipCode)
    {
        value = RegexService
            .GetOnlyNumbers(value);

        if (!IsValid(value))
        {
            zipCode = default;

            return false;
        }

        zipCode = new ZipCode(value);

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
