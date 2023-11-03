using System.Diagnostics.CodeAnalysis;
using BrazilianTypes.Types;

namespace Test.Types;

[ExcludeFromCodeCoverage]
public class CnpjTest
{
    # region ---- create -------------------------------------------------------

    [Theory]
    [InlineData("49.700.512/0001-50")]
    [InlineData("49700512000150")]
    [InlineData("49-700-512-0001-50")]
    [InlineData("49.700.512/000150")]
    [InlineData("49700.512/0001-50")]
    [InlineData("49700512/0001-50")]
    public void ShouldCreateCnpj(string cnpj)
    {
        Cnpj parsedCpf = cnpj;

        Assert.Equal(
            expected: "49700512000150",
            actual: parsedCpf
        );
    }

    # endregion

    # region ---- throw --------------------------------------------------------

    [Theory]
    [InlineData("49.700.512/0001-52")]
    [InlineData("11.111.111/1111-11")]
    [InlineData("11111111111111")]
    [InlineData("49700512000152")]
    [InlineData("aaBBaaBBaaBBaa")]
    [InlineData("49.700.512/000-52")]
    [InlineData("aa.aabb.aaa/aabb-aa")]
    public void ShouldThrow(string cnpj) => Assert
        .Throws<ArgumentException>(() => { Cnpj _ = cnpj; });

    # endregion

    # region ---- mask ---------------------------------------------------------

    [Theory]
    [InlineData("49.700.512/0001-50")]
    [InlineData("49700512000150")]
    [InlineData("49.700.512/0001/50")]
    [InlineData("49/700/512/0001/50")]
    [InlineData("49-700-512-0001-50")]
    [InlineData("49.700.512.0001.50")]
    public void ShouldGenerateMask(string cnpj)
    {
        Cnpj parsedCnpj = cnpj;

        Assert.Equal(
            expected: "49.700.512/0001-50",
            actual: parsedCnpj.Mask
        );
    }

    # endregion

    # region ---- digits -------------------------------------------------------

    [Theory]
    [InlineData("49.700.512/0001-50")]
    [InlineData("67.267.619/0001-38")]
    [InlineData("40.405.925/0001-37")]
    [InlineData("23.575.046/0001-34")]
    public void ShouldGetDigits(string cnpj)
    {
        Cnpj parsedCnpj = cnpj;

        Assert.Equal(
            expected: cnpj.Split(separator: "-")[1],
            actual: parsedCnpj.Digits
        );
    }
    # endregion

    # region ---- generation ---------------------------------------------------

    [Fact]
    public void ShouldGenerateCnpj()
    {
        for (var i = 0; i < 100; i++)
        {
            var cnpj = Cnpj.Generate();

            Assert.True(Cnpj.TryParse(cnpj, out _));
        }
    }

    # endregion
}
