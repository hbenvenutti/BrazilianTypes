using BrazilianTypes.Exceptions;
using BrazilianTypes.Extensions;
using BrazilianTypes.Interfaces;
using BrazilianTypes.Services;

namespace BrazilianTypes.Types;

/// <summary>
/// Representa um número de CPF (Cadastro de Pessoas Físicas) válido.
/// </summary>

public readonly struct Cpf : IType<Cpf>, IMaskedType, IGenerable<Cpf>
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

    public string Mask => RegexService.MaskCpf(_value);

    /// <summary>
    /// Obtém os dígitos do CPF.
    /// </summary>

    public string Digits => _value[9..];

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
            throw new InvalidValueException(
                message: ErrorMessage,
                value: value,
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
        value = RegexService
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
        if (cpf.Length != 11) { return false; }

        if (cpf.HasAllCharsEqual()) { return false; }

        return cpf.EndsWith(
            value: GenerateDigits(cpf[..9]),
            StringComparison.Ordinal
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

        var result = $"{str}{digits}";

        if (str.HasAllCharsEqual()) { return Generate(); }

        return result;
    }

    # endregion

    # region ---- auxiliars ----------------------------------------------------

    private static string GenerateDigits(string cpf)
    {
        var digit1 = GetRest(Sum(cpf, Mult1));

        var digit2 = GetRest(Sum(cpf + digit1, Mult2));

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

    /// <summary>
    /// Converts a string into a <see cref="Cpf"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator Cpf(string value) => Parse(value);

    /// <summary>
    /// Converts a <see cref="Cpf"/> into a string.
    /// </summary>
    /// <param name="cpf"></param>
    /// <returns></returns>
    public static implicit operator string(Cpf cpf) => cpf._value;

    #endregion
}
