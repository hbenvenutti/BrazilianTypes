using BrazilianTypes.Exceptions;
using BrazilianTypes.Interfaces;

namespace BrazilianTypes.Types;

/// <summary>
/// Represents a Brazilian state abbreviation (UF).
/// </summary>

public readonly struct Uf : IType<Uf>
{
    /// <summary>
    /// Gets the error message for an invalid UF.
    /// </summary>

    public static string ErrorMessage => "UF is invalid.";

    # region ---- private properties -------------------------------------------

    private readonly string _value;

    private enum State
    {
        AC, AL, AM, AP, BA, CE, DF, ES, GO, MA, MG, MS, MT, PA, PB, PE, PI, PR,
        RJ, RN, RO, RR, RS, SC, SE, SP, TO
    }

    # endregion

    # region ---- constructor --------------------------------------------------

    private Uf(string value)
    {
        _value = value;
    }

    # endregion

    # region ---- parse --------------------------------------------------------

    private static Uf Parse(string value)
    {
        if (!TryParse(value, out var uf))
        {
            throw new InvalidValueException(
                message: ErrorMessage,
                value: value,
                paramName: nameof(value)
            );
        }

        return uf;
    }

    /// <summary>
    /// Tries to parse a string representation of a UF and returns a value
    /// indicating whether the parsing was successful.
    /// </summary>
    /// <param name="value">The string representation of the UF.</param>
    /// <param name="uf">When this method returns, contains the parsed UF if
    /// the parsing was successful; otherwise, contains the default value of
    /// <see cref="Uf"/>.
    /// </param>
    /// <returns><c>true</c> if the parsing was successful; otherwise,
    /// <c>false</c>.
    /// </returns>

    public static bool TryParse(string value, out Uf uf)
    {
        uf = default;

        if (string.IsNullOrWhiteSpace(value)) { return false;}

        value = value.ToUpper();

        if (!IsValid(value)) { return false; }

        uf = new Uf(value);

        return true;
    }

    # endregion

    # region ---- validation ---------------------------------------------------

    private static bool IsValid(string value)
    {
        if (value.Length != 2) { return false; }

        return Enum.TryParse(value, out State _);
    }

    # endregion

    # region ---- operators ----------------------------------------------------

    /// <summary></summary>
    public static implicit operator Uf(string value) => Parse(value);

    /// <summary></summary>
    public static implicit operator string(Uf uf) => uf._value;

    # endregion
}
