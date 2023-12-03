using System.Text.RegularExpressions;

namespace BrazilianTypes.Services;

internal readonly partial struct RegexService
{
    # region ---- remove mask --------------------------------------------------

    /// <summary>
    /// Obtém uma instância de Regex para remover todos os caracteres não numéricos.
    /// </summary>
    /// <returns>Instância de Regex para remover caracteres não numéricos.</returns>

    [GeneratedRegex(pattern: @"[^\d]")]
    private static partial Regex OnlyNumbers();

    /// <summary>
    /// Remove todos os caracteres não numéricos de uma string.
    /// </summary>
    /// <param name="value">A string da qual os caracteres não numéricos serão removidos.</param>
    /// <returns>A string resultante com apenas números.</returns>

    internal static string GetOnlyNumbers(string value) => OnlyNumbers()
        .Replace(input: value, replacement: "");

    # endregion

    # region ---- cpf ----------------------------------------------------------

    [GeneratedRegex(pattern: @"^(\d{3})(\d{3})(\d{3})(\d{2}$)")]
    private static partial Regex CpfMask();

    internal static string MaskCpf(string value) => CpfMask()
        .Replace(input: value, replacement: "$1.$2.$3-$4");

    internal static string SecurityMaskCpf(string value) => CpfMask()
        .Replace(input: value, replacement: "***.$2.$3-**");

    # endregion

    # region ---- zip code -----------------------------------------------------

    [GeneratedRegex(pattern: @"^(\d{5})(\d{3})$")]
    private static partial Regex ZipCodeMask();

    internal static string MaskZipCode(string value) => ZipCodeMask()
        .Replace(input: value, replacement: @"$1-$2");

    # endregion

    # region ---- phone --------------------------------------------------------

    [GeneratedRegex(pattern: @"^(\d{2})(\d{4,5})(\d{4})$")]
    private static partial Regex PhoneMask();

    internal static string MaskPhone(string value) => PhoneMask()
        .Replace(input: value, replacement: @"($1) $2-$3");

    # endregion

    # region ---- cnpj ---------------------------------------------------------

    [GeneratedRegex(pattern: @"^(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})$")]
    private static partial Regex CnpjMask();

    internal static string MaskCnpj(string value) => CnpjMask()
        .Replace(input: value, replacement: @"$1.$2.$3/$4-$5");

    internal static string SecurityMaskCnpj(string value) => CnpjMask()
        .Replace(input: value, replacement: "**.$2.$3/****-**");

    # endregion

    # region ---- remove white space -------------------------------------------

    [GeneratedRegex(pattern: @"\s+")]
    private static partial Regex WhiteSpace();

    internal static string RemoveWhiteSpace(string value) => WhiteSpace()
        .Replace(input: value, replacement: "");

    # endregion
}
