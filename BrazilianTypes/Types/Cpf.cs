using BrazilianTypes.Exceptions;
using BrazilianTypes.Extensions;
using BrazilianTypes.Interfaces;
using BrazilianTypes.Services;

namespace BrazilianTypes.Types;

/// <summary>
/// Represents CPF (Cadastro de Pessoas Físicas) number.
/// </summary>

public readonly struct Cpf : IType<Cpf>, IMaskedType, IGenerable<Cpf>, ISecurityMaskedType
{
    # region ---- private properties -------------------------------------------

    private readonly string _value;

    private static readonly byte[] Mult1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
    private static readonly byte[] Mult2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

    # endregion

    # region ---- public properties --------------------------------------------

    /// <summary> Default error message for an invalid CPF.</summary>
    public static string ErrorMessage => "CPF is invalid.";

    ///<summary>Gets the CPF formatted with the mask (###.###.###-##).</summary>
    public string Mask => RegexService.MaskCpf(_value);

    /// <summary>Gets the digits of the CPF.</summary>
    public string Digits => _value[9..];

    ///<summary>Gets the CPF formatted with the security mask (***.###.###-**).</summary>
    public string SecurityMask => RegexService.MaskCpfSecurity(_value);

    # endregion

    # region ---- constructor --------------------------------------------------

    private Cpf(string value)
    {
        _value = value;
    }

    # endregion

    # region ---- parse --------------------------------------------------------

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
    /// Tries to parse the specified value and returns a Cpf instance.
    /// </summary>
    /// <param name="value">The string value to parse.</param>
    /// <param name="cpf">When this method returns, contains the parsed Cpf
    /// instance if the parsing was successful, or the default value if the
    /// parsing failed.</param>
    /// <returns><c>true</c> if the parsing was successful; otherwise,
    /// <c>false</c>.</returns>

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
    /// Generates a random CPF (Cadastro de Pessoas Físicas) number.
    /// </summary>
    /// <returns>A randomly generated CPF number.</returns>
    /// <remarks>
    /// The generated CPF number is guaranteed to be valid.
    /// </remarks>

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

        return result.HasAllCharsEqual()
            ? Generate()
            : result;
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

    /// <summary></summary>
    public static implicit operator Cpf(string value) => Parse(value);

    /// <summary></summary>
    public static implicit operator string(Cpf cpf) => cpf._value;

    #endregion
}
