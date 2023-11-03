using System.Diagnostics.CodeAnalysis;
using BrazilianTypes.Types;

namespace Test.Types;

[ExcludeFromCodeCoverage]
public class UfTest
{
    # region ---- create -------------------------------------------------------

    [Theory]
    [InlineData("AC")]
    [InlineData("AL")]
    [InlineData("AM")]
    [InlineData("AP")]
    [InlineData("BA")]
    [InlineData("CE")]
    [InlineData("DF")]
    [InlineData("ES")]
    [InlineData("GO")]
    [InlineData("MA")]
    [InlineData("MG")]
    [InlineData("MS")]
    [InlineData("MT")]
    [InlineData("PA")]
    [InlineData("PB")]
    [InlineData("PE")]
    [InlineData("PI")]
    [InlineData("PR")]
    [InlineData("RJ")]
    [InlineData("RN")]
    [InlineData("RO")]
    [InlineData("RR")]
    [InlineData("RS")]
    [InlineData("SC")]
    [InlineData("SE")]
    [InlineData("SP")]
    [InlineData("TO")]
    public void ShouldCreateAUf(string uf)
    {
        Uf result = uf;
        Assert.Equal(
            expected: uf,
            actual:result
        );
    }

    # endregion

    # region ---- throw --------------------------------------------------------

    [Theory]
    [InlineData("A")]
    [InlineData("AA")]
    [InlineData("AAA")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    [InlineData("@#")]
    public void ShouldThrowArgumentException(string uf) =>
        Assert.Throws<ArgumentException>(() => { Uf _ = uf; });

    # endregion
}
