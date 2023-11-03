using System.Diagnostics.CodeAnalysis;
using BrazilianTypes.Types;

namespace Test.Types;

[ExcludeFromCodeCoverage]
public class CpfTest
{
    # region ---- create -------------------------------------------------------

    [Theory]
    [InlineData("001.815.600-20")]
    [InlineData("00181560020")]
    [InlineData("001/815/600/20")]
    [InlineData("001-815-600-20")]
    [InlineData("001-815-600a-20")]
    [InlineData("0-0-1-8-1-5-6-0-0-2-0")]
    public void ShouldCreateCpfWithoutMask(string cpf)
    {
        Cpf parsedCpf = cpf;

        Assert.Equal(
            expected: "00181560020",
            actual: parsedCpf
        );
    }

    # endregion

    # region ---- throw --------------------------------------------------------

    [Theory]
    [InlineData("001.815.601-20")]
    [InlineData("aaa.bbb.ccc-dd")]
    [InlineData("@34.#%&.()!-?:")]
    [InlineData("111.111.111-11")]
    [InlineData("001.815.60-20")]
    [InlineData("001.815.6001-20")]
    [InlineData("001.815.60a-20")]
    public void ShouldThrow(string cpf) => Assert.
        Throws<ArgumentException>(() => { Cpf _ = cpf; });

    # endregion

    # region ---- mask ---------------------------------------------------------

    [Theory]
    [InlineData("001.815.600-20")]
    [InlineData("00181560020")]
    [InlineData("001/815/600/20")]
    [InlineData("001-815-600-20")]
    [InlineData("001-815-600a-20")]
    [InlineData("0-0-1-8-1-5-6-0-0-2-0")]
    public void ShouldGenerateMask(string cpf)
    {
        Cpf parsedCpf = cpf;

        Assert.Equal(
            expected: "001.815.600-20",
            actual: parsedCpf.Mask
        );
    }

    # endregion

    # region ---- digits -------------------------------------------------------

    [Theory]
    [InlineData("001.815.600-20")]
    [InlineData("682.366.550-59")]
    [InlineData("688.401.110-69")]
    [InlineData("605.040.520-47")]
    [InlineData("749.527.540-57")]
    public void ShouldGetDigits(string cpf)
    {
        Cpf parsedCpf = cpf;

        var digits = cpf.Split('-')[1];

        Assert.Equal(
            expected: digits,
            actual: parsedCpf.Digits
        );
    }

    # endregion

    # region ---- generation ---------------------------------------------------

    [Fact]
    public void ShouldGenerateCpf()
    {
        for (var i = 0; i < 100; i++)
        {
            var cpf = Cpf.Generate();

            Assert.True(Cpf.TryParse(cpf, out _));
        }
    }

    # endregion
}
