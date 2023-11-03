using System.Text.RegularExpressions;

namespace BrazilianTypes.Structs;

internal readonly struct RegexPatterns
{
    # region ---- numbers ------------------------------------------------------

    private static readonly Regex OnlyNumbersRegex =
        new Regex(@"[^\d]");
    internal static string GetOnlyNumbers(string value) => OnlyNumbersRegex
        .Replace(value, "");

    # endregion

    # region ---- cpf ----------------------------------------------------------

    private static readonly Regex CpfMaskRegex =
        new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
    internal static string MaskCpf(string value) => CpfMaskRegex
        .Replace(value, @"$1.$2.$3-$4");

    # endregion

    # region ---- cep ----------------------------------------------------------

    private static readonly Regex ZipCodeMaskRegex =
        new Regex(@"^(\d{5})-(\d{3})$");
    internal static string MaskZipCode(string value) => ZipCodeMaskRegex
        .Replace(value, @"$1-$2");

    # endregion

    # region ---- phone --------------------------------------------------------

    private static readonly Regex PhoneMaskRegex =
        new Regex(@"^(\d{2})\d{4,5}-\d{4}$");
    internal static string MaskPhone(string value) => PhoneMaskRegex
        .Replace(value, @"($1) $2-$3");

    # endregion

    # region ---- cnpj ---------------------------------------------------------

    private static readonly Regex CnpjMaskRegex =
        new Regex(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$");
    internal static string MaskCnpj(string value) => CnpjMaskRegex
        .Replace(value, @"$1.$2.$3/$4-$5");

    # endregion
}
