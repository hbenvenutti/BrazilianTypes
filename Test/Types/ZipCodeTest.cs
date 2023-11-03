using System.Diagnostics.CodeAnalysis;
using BrazilianTypes.Types;

namespace Test.Types;

[ExcludeFromCodeCoverage]
public class ZipCodeTest
{
    # region ---- create -------------------------------------------------------

    [Theory]
    [InlineData("12345-678")]
    [InlineData("12345678")]
    [InlineData("12-345-678")]
    [InlineData("12.345.678")]
    public void ShouldCreateZipCode(string zipCode)
    {
        ZipCode parsedZipCode = zipCode;

        Assert.Equal(
            expected: "12345678",
            actual: parsedZipCode
        );
    }

    # endregion

    # region ---- throw --------------------------------------------------------

    [Theory]
    [InlineData("12345-67")]
    [InlineData("1234567")]
    [InlineData("12345-6789")]
    [InlineData("123456789")]
    [InlineData("aaBBaaBBaaBBaa")]
    public void ShouldThrow(string zipCode) => Assert
        .Throws<ArgumentException>(() => { ZipCode _ = zipCode; });

    # endregion

    # region ---- mask ---------------------------------------------------------

    [Theory]
    [InlineData("12345-678")]
    [InlineData("12345678")]
    [InlineData("12-345-678")]
    [InlineData("12.345.678")]
    public void ShouldGenerateMask(string zipCode)
    {
        ZipCode parsedZipCode = zipCode;

        Assert.Equal(
            expected: "12345-678",
            actual: parsedZipCode.Mask
        );
    }

    # endregion

    # region ---- generate -----------------------------------------------------

    [Fact]
    public void ShouldGenerateZipCode()
    {
        for (var i = 0; i < 100; i++)
        {
            var zipCode = ZipCode.Generate();

            Assert.True(
                condition: ZipCode.TryParse(zipCode, out _)
            );
        }
    }

    # endregion
}
