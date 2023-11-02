using BrazilianTypes.Extensions;
using BrazilianTypes.Interfaces;
using BrazilianTypes.Structs;

namespace BrazilianTypes.Types;

/// <summary>
/// Representa um número de CPF (Cadastro de Pessoas Físicas) válido.
/// </summary>

public readonly struct Cpf : IType<Cpf>, IMaskedType
{
    # region ---- constants ----------------------------------------------------

    /// <summary>
    /// Mensagem de erro padrão para CPF inválido.
    /// </summary>

    public static string ErrorMessage => "CPF is invalid.";

    private static readonly byte[] Mult1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
    private static readonly byte[] Mult2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

    # endregion

    # region ---- properties ---------------------------------------------------

    private readonly string _value;

    /// <summary>
    /// Obtém o CPF formatado com a máscara (###.###.###-##).
    /// </summary>

    public string Mask => RegexPatterns.MaskCpf(_value);

    /// <summary>
    /// Obtém os dígitos do CPF.
    /// </summary>

    public string Digits => _value[10..];

    # endregion

    # region ---- constructor --------------------------------------------------

    /// <summary>
    /// Construtor privado para criar uma instância de Cpf a partir de uma string.
    /// </summary>
    /// <param name="value">O valor do CPF.</param>

    private Cpf(string value)
    {
        _value = value;
    }

    # endregion

    # region ---- parse --------------------------------------------------------

    /// <summary>
    /// Converte uma string em um objeto Cpf.
    /// </summary>
    /// <param name="value">A string representando o CPF.</param>
    /// <returns>O objeto Cpf correspondente.</returns>
    private static Cpf Parse(string value)
    {
        if (!TryParse(value, out var cpf))
        {
            throw new ArgumentException(
                message: ErrorMessage,
                paramName: nameof(value)
            );
        }

        return cpf;
    }

    /// <summary>
    /// Tenta converter uma string em um objeto Cpf.
    /// </summary>
    /// <param name="value">A string representando o CPF.</param>
    /// <param name="cpf">O objeto Cpf resultante, se a conversão for bem-sucedida.</param>
    /// <returns>True se a conversão for bem-sucedida; caso contrário, False.</returns>

    public static bool TryParse(string value, out Cpf cpf)
    {
        value = RegexPatterns
            .GetOnlyNumbers(value);

        if (!IsValid(value))
        {
            cpf = default;

            return false;
        }

        cpf = new Cpf(value);

        return true;
    }

    # endregion

    # region ---- validation ---------------------------------------------------

    /// <summary>
    /// Verifica se um CPF é válido.
    /// </summary>
    /// <param name="cpf">O CPF a ser validado.</param>
    /// <returns>True se o CPF for válido; caso contrário, False.</returns>

    private static bool IsValid(string cpf )
    {
        if (!cpf.IsNumeric()) { return false; }

        if (cpf.Length != 11) { return false; }

        if (cpf.HasAllCharsEqual()) { return false; }

        return cpf.EndsWith(
            value: GenerateDigits(cpf[..9]),
            StringComparison.InvariantCulture
        );
    }

    # endregion

    # region ---- generate -----------------------------------------------------

    /// <summary>
    /// Gera um número de CPF válido.
    /// </summary>
    /// <returns>O CPF gerado.</returns>

    public static Cpf Generate()
    {
        var random = new Random();

        var cpf = new byte[9];

        for (var i = 0; i < cpf.Length; i++)
        {
            cpf[i] = (byte)random.Next(10);
        }

        var str = string.Join("", cpf);

        var digits = GenerateDigits(str);

        return $"{str}{digits}";
    }

    # endregion

    # region ---- auxiliars ----------------------------------------------------

    private static string GenerateDigits(string cpf)
    {
        var sum = Sum(cpf, Mult1);

        var rest = GetRest(sum);

        var digit1 = rest;

        cpf += rest;

        sum = Sum(cpf, Mult2);

        rest = GetRest(sum);

        var digit2 = rest;

        return $"{digit1}{digit2}";
    }

    private static int Sum(string tempCpf, IReadOnlyList<byte> mult)
    {
        var sum = 0;

        for (var i = 0; i < mult.Count; i++ )
        {
            sum += (tempCpf[i] - '0') * mult[i];
        }

        return sum;
    }

    private static byte GetRest(int sum)
    {
        var rest = sum % 11;

        return (byte)(rest < 2
            ? 0
            : 11 - rest);
    }

    # endregion

    # region ---- implicit operators -------------------------------------------

    public static implicit operator Cpf(string value) => Parse(value);

    public static implicit operator string(Cpf cpf) => cpf._value;

    #endregion
}
