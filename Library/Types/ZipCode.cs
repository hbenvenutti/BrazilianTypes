using BrazilianTypes.Interfaces;
using BrazilianTypes.Structs;

namespace BrazilianTypes.Types;

/// <summary>
/// Representa um CEP (Código de Endereçamento Postal) brasileiro.
/// </summary>

public readonly struct ZipCode : IType<ZipCode>, IMaskedType
{
    # region ---- constants ----------------------------------------------------

    /// <summary>
    /// Mensagem de erro para CEPs inválidos.
    /// </summary>

    public static string ErrorMessage => "Zip code is invalid.";

    # endregion

    private readonly string _value;

    /// <summary>
    /// Obtém o valor do CEP com a máscara aplicada (#####-###).
    /// </summary>

    public string Mask => RegexPatterns.MaskZipCode(_value);

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
        value = RegexPatterns
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

    # region ---- operators ----------------------------------------------------

    public static implicit operator ZipCode(string value) => Parse(value);
    public static implicit operator string(ZipCode zipCode) => zipCode._value;

    # endregion
}
