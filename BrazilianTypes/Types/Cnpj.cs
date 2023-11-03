using BrazilianTypes.Extensions;
using BrazilianTypes.Interfaces;
using BrazilianTypes.Structs;

namespace BrazilianTypes.Types;

/// <summary>
/// Represents a Brazilian CNPJ (Cadastro Nacional da Pessoa Jurídica) number.
/// </summary>
public readonly struct Cnpj : IMaskedType
{
    # region ---- properties ---------------------------------------------------

    /// <summary>
    /// Gets the error message associated with invalid CNPJ numbers.
    /// </summary>
    public const string ErrorMessage = "Invalid CNPJ";

    /// <summary>
    /// Gets the CNPJ with a masking pattern applied.
    /// </summary>
    public string Mask => RegexPatterns.MaskCnpj(_value);

    /// <summary>
    /// Gets the digits of the CNPJ.
    /// </summary>
    public string Digits => _value[12..];

    private readonly string _value;

    private static readonly byte[] Mult1 =
        { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

    private static readonly byte[] Mult2 =
        { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

    # endregion

    # region ---- constructor --------------------------------------------------

    private Cnpj(string value)
    {
        _value = value;
    }

    # endregion

    # region ---- parse --------------------------------------------------------

    private static Cnpj Parse(string value)
    {
        if (!TryParse(value, out var cnpj))
        {
            throw new ArgumentException(
                message: ErrorMessage,
                paramName: nameof(value)
            );
        }

        return cnpj;
    }

    /// <summary>
    /// Attempts to convert a string into a <see cref="Cnpj"/> object.
    /// </summary>
    /// <param name="value">The string representing the CNPJ.</param>
    /// <param name="cnpj">The resulting <see cref="Cnpj"/> object if the conversion is successful.</param>
    /// <returns>True if the conversion is successful; otherwise, False.</returns>

    public static bool TryParse(string value, out Cnpj cnpj)
    {
        value = RegexPatterns
            .GetOnlyNumbers(value);

        if (!IsValid(value))
        {
            cnpj = default;

            return false;
        }

        cnpj = new Cnpj(value);

        return true;
    }

    # endregion

    # region ---- validation ---------------------------------------------------

    private static bool IsValid(string cnpj)
    {
        if (cnpj.Length != 14) { return false; }

        if (!cnpj.IsNumeric()) { return false; }

        if (cnpj.HasAllCharsEqual()) { return false;}

        return cnpj.EndsWith(
            value: GenerateDigits(cnpj[..12]),
            comparisonType: StringComparison.Ordinal
        );
    }

    # endregion

    # region ---- auxiliary ----------------------------------------------------

    private static int Sum(string tempCnpj, byte[] mult)
    {
        var sum = 0;

        for (var i = 0; i < mult.Length; i++)
        {
            sum += (tempCnpj[i] - '0') * mult[i];
        }

        return sum;
    }

    private static int GetRest(int sum)
    {
        var rest = sum % 11;

        return rest < 2
            ? 0
            : 11 - rest;
    }

    private static string GenerateDigits(string cnpj)
    {
        var digit1 = GetRest(Sum(cnpj, Mult1));

        var digit2 = GetRest(Sum(cnpj + digit1, Mult2));

        return $"{digit1}{digit2}";
    }

    # endregion

    # region ---- generation ---------------------------------------------------

    /// <summary>
    /// Generates a random valid CNPJ.
    /// </summary>
    /// <returns>A randomly generated valid CNPJ.</returns>
    public static Cnpj Generate()
    {
        var random = new Random();

        var cnpj = new byte[12];

        for (var i = 0; i < cnpj.Length; i++)
        {
            cnpj[i] = (byte)random.Next(10);
        }

        var str = string.Join("", cnpj);

        var digits = GenerateDigits(str);

        return $"{str}{digits}";
    }

    # endregion

    # region ---- operators ----------------------------------------------------

    /// <summary>
    /// Converts a string into a <see cref="Cnpj"/> object.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator Cnpj(string value) => Parse(value);

    /// <summary>
    /// Converts a <see cref="Cnpj"/> object into a string.
    /// </summary>
    /// <param name="cnpj"></param>
    /// <returns></returns>
    public static implicit operator string(Cnpj cnpj) => cnpj._value;

    # endregion
}
