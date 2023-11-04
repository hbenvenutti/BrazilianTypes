using BrazilianTypes.Interfaces;

namespace BrazilianTypes.Types;

/// <summary>
/// Representa uma Unidade Federativa (UF) do Brasil.
/// </summary>

public readonly struct Uf : IType<Uf>
{
    /// <summary>
    /// Mensagem de erro padrão quando a UF é inválida.
    /// </summary>

    public static string ErrorMessage => "UF is invalid.";

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

    /// <summary>
    /// Tenta analisar uma string e retorna uma instância de Uf correspondente.
    /// </summary>
    /// <param name="value">Valor a ser analisado.</param>
    /// <param name="uf">Instância de Uf, se a análise for bem-sucedida.</param>
    /// <returns>True se a análise for bem-sucedida, False caso contrário.</returns>

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

    /// <summary>
    /// Converts a string into a <see cref="Uf"/> instance.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator Uf(string value) => Parse(value);

    /// <summary>
    /// Converts a <see cref="Uf"/> instance into a string.
    /// </summary>
    /// <param name="uf"></param>
    /// <returns></returns>
    public static implicit operator string(Uf uf) => uf._value;

    # endregion
}
