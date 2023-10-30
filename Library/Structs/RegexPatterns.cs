using System.Text.RegularExpressions;

namespace BrazilianTypes.Structs;

internal readonly partial struct RegexPatterns
{
    private const string CpfReplacement = @"$1.$2.$3-$4";

    public static string GetOnlyNumbers(string value) => OnlyNumbers()
        .Replace(input: value, replacement: "");

    public static string GetCpfMask(string value) => CpfMask()
        .Replace(value, CpfReplacement);

    [GeneratedRegex(pattern: @"[^\d]")]
    private static partial Regex OnlyNumbers();

    [GeneratedRegex(pattern: @"^\d{3}\.\d{3}\.\d{3}-\d{2}$")]
    private static partial Regex CpfMask();
}
