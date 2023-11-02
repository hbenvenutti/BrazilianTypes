namespace BrazilianTypes.Types;

public readonly struct Uf
{
    public const string ErrorMessage = "UF is invalid.";

    private readonly string _value;

    private enum State
    {
        AC, AL, AM, AP, BA, CE, DF, ES, GO, MA, MG, MS, MT, PA, PB, PE, PI, PR,
        RJ, RN, RO, RR, RS, SC, SE, SP, TO
    }

    private Uf(string value)
    {
        _value = value;
    }

    # region ---- parse --------------------------------------------------------

    private static Uf Parse(string value)
    {
        if (!TryParse(value, out var uf))
        {
            throw new ArgumentException(
                message: ErrorMessage,
                paramName: nameof(value)
            );
        }

        return uf;
    }

    public static bool TryParse(string value, out Uf uf)
    {
        value = value.ToUpper();

        if (!IsValid(value))
        {
            uf = default;

            return false;
        }

        uf = new Uf(value);

        return true;
    }

    # endregion

    # region ---- validation ---------------------------------------------------

    private static bool IsValid(string value)
    {
        if (value.Length != 2)
            return false;

        return Enum.TryParse(value, out State _);
    }

    # endregion

    # region ---- operators ----------------------------------------------------

    public static implicit operator Uf(string value) => Parse(value);
    public static implicit operator string(Uf uf) => uf._value;

    # endregion
}
