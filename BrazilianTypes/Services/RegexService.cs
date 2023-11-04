using System.Text.RegularExpressions;

namespace BrazilianTypes.Services;

/// <summary>
/// Classe que contém padrões de expressões regulares.
/// </summary>

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

    /// <summary>
    /// Obtém uma instância de Regex para validar o padrão de CPF (###.###.###-##).
    /// </summary>
    /// <returns>Instância de Regex para validar CPF.</returns>

    [GeneratedRegex(pattern: @"^(\d{3})(\d{3})(\d{3})(\d{2}$)")]
    private static partial Regex CpfMask();

    /// <summary>
    /// Aplica a máscara de CPF (###.###.###-##) a uma string.
    /// </summary>
    /// <param name="value">A string contendo o CPF.</param>
    /// <returns>O CPF formatado com a máscara.</returns>

    internal static string MaskCpf(string value) => CpfMask()
        .Replace(input: value, replacement: @"$1.$2.$3-$4");

    # endregion

    # region ---- zip code -----------------------------------------------------

    /// <summary>
    /// Obtém uma instância de Regex para validar o padrão de CEP (#####-###).
    /// </summary>
    /// <returns>Instância de Regex para validar CEP.</returns>

    [GeneratedRegex(pattern: @"^(\d{5})(\d{3})$")]
    private static partial Regex ZipCodeMask();

    /// <summary>
    /// Aplica a máscara de CEP (#####-###) a uma string.
    /// </summary>
    /// <param name="value">A string contendo o CEP.</param>
    /// <returns>O CEP formatado com a máscara.</returns>

    internal static string MaskZipCode(string value) => ZipCodeMask()
        .Replace(input: value, replacement: @"$1-$2");

    # endregion

    # region ---- phone --------------------------------------------------------

    [GeneratedRegex(pattern: @"^(\d{2})(\d{4,5})(\d{4})$")]
    private static partial Regex PhoneMask();

    /// <summary>
    /// Aplica a máscara de Telefone ((##) #####-####) a uma string.
    /// </summary>
    /// <param name="value">A string contendo o Phone.</param>
    /// <returns>O Phone formatado com a máscara.</returns>
    internal static string MaskPhone(string value) => PhoneMask()
        .Replace(input: value, replacement: @"($1) $2-$3");

    # endregion

    # region ---- cnpj ---------------------------------------------------------

    [GeneratedRegex(pattern: @"^(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})$")]
    private static partial Regex CnpjMask();

    /// <summary>
    /// Aplica a máscara de CNPJ (##.###.###/####-##) a uma string.
    /// </summary>
    /// <param name="value">A string contendo o Cnpj.</param>
    /// <returns>O Cnpj formatado com a máscara.</returns>
    internal static string MaskCnpj(string value) => CnpjMask()
        .Replace(input: value, replacement: @"$1.$2.$3/$4-$5");

    # endregion

    # region ---- remove white space -------------------------------------------

    [GeneratedRegex(pattern: @"\s+")]
    private static partial Regex WhiteSpace();

    internal static string RemoveWhiteSpace(string value) => WhiteSpace()
        .Replace(input: value, replacement: "");

    # endregion
}
