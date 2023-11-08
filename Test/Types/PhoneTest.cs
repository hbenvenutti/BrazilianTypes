using System.Diagnostics.CodeAnalysis;
using BrazilianTypes.Exceptions;
using BrazilianTypes.Types;

namespace Test.Types;

[ExcludeFromCodeCoverage]
public class PhoneTest
{
    # region ---- create -------------------------------------------------------

    [Theory]
    [InlineData("11 91234-5678")]
    [InlineData("(11) 91234-5678")]
    [InlineData("11 912345678")]
    [InlineData("11912345678")]
    public void ShouldCreateAMobilePhone(string phone)
    {
        Phone result = phone;

        Assert.Equal(
            expected: "11912345678",
            actual: result
        );
    }

    [Theory]
    [InlineData("(11) 3123-5678")]
    [InlineData("11 3123-5678")]
    [InlineData("11 3123 5678")]
    [InlineData("1131235678")]
    public void ShouldCreateARegularPhone(string phone)
    {
        Phone result = phone;

        Assert.Equal(
            expected: "1131235678",
            actual: result
        );
    }

    # endregion

    # region ---- throw --------------------------------------------------------

    [Theory]
    [InlineData("91234-5678")]
    [InlineData("191234-5678")]
    [InlineData("11 91234-56789")]
    [InlineData("11 8123-45678")]
    [InlineData("11 7123-45678")]
    [InlineData("11 6123-45678")]
    [InlineData("11 5123-45678")]
    [InlineData("11 4123-45678")]
    [InlineData("11 3123-45678")]
    [InlineData("11 2123-45678")]
    [InlineData("11 1123-45678")]
    [InlineData("11 0123-45678")]
    [InlineData("11 9123-5678")]
    [InlineData("11 8123-5678")]
    [InlineData("11 7123-5678")]
    [InlineData("11 6123-5678")]
    [InlineData("11 5123-5678")]
    [InlineData("11 4123-5678")]
    [InlineData("11 2123-5678")]
    [InlineData("11 1123-5678")]
    [InlineData("11 0123-5678")]
    public void ShouldThrowArgumentException(string phone) =>
        Assert.Throws<InvalidValueException>(() => { Phone _ = phone; });

    # endregion

    # region ---- mask ---------------------------------------------------------

    [Theory]
    [InlineData("11912345678", "(11) 91234-5678")]
    [InlineData("(11) 91234-5678", "(11) 91234-5678")]
    [InlineData("11 91234-5678", "(11) 91234-5678")]
    [InlineData("11 91234 5678", "(11) 91234-5678")]
    [InlineData("11 912345678", "(11) 91234-5678")]
    [InlineData("1131235678", "(11) 3123-5678")]
    [InlineData("(11) 3123-5678", "(11) 3123-5678")]
    [InlineData("11 3123-5678", "(11) 3123-5678")]
    [InlineData("11 3123 5678", "(11) 3123-5678")]
    [InlineData("11 31235678", "(11) 3123-5678")]
    public void ShouldMaskPhone(string phone, string expected)
    {
        Phone result = phone;

        Assert.Equal(
            expected: expected,
            actual: result.Mask
        );
    }

    # endregion

    # region ---- Ddd ----------------------------------------------------------

    [Theory]
    [InlineData("11912345678", "11")]
    [InlineData("(11) 91234-5678", "11")]
    [InlineData("11 91234-5678", "11")]
    [InlineData("11 91234 5678", "11")]
    [InlineData("11 912345678", "11")]
    [InlineData("1131235678", "11")]
    [InlineData("(11) 3123-5678", "11")]
    [InlineData("11 3123-5678", "11")]
    [InlineData("11 3123 5678", "11")]
    [InlineData("11 31235678", "11")]
    public void ShouldGetDdd(string phone, string expected)
    {
        Phone result = phone;

        Assert.Equal(
            expected: expected,
            actual: result.Ddd
        );
    }

    # endregion

    # region ---- Number -------------------------------------------------------

    [Theory]
    [InlineData("11912345678", "912345678")]
    [InlineData("(11) 91234-5678", "912345678")]
    [InlineData("11 91234-5678", "912345678")]
    [InlineData("11 91234 5678", "912345678")]
    [InlineData("11 912345678", "912345678")]
    [InlineData("1131235678", "31235678")]
    [InlineData("(11) 3123-5678", "31235678")]
    [InlineData("11 3123-5678", "31235678")]
    [InlineData("11 3123 5678", "31235678")]
    [InlineData("11 31235678", "31235678")]
    public void ShouldGetNumber(string phone, string expected)
    {
        Phone result = phone;

        Assert.Equal(
            expected: expected,
            actual: result.Number
        );
    }

    # endregion

    # region ---- IsMobile -----------------------------------------------------

    [Theory]
    [InlineData("11912345678", true)]
    [InlineData("(11) 91234-5678", true)]
    [InlineData("11 91234-5678", true)]
    [InlineData("11 91234 5678", true)]
    [InlineData("11 912345678", true)]
    [InlineData("1131235678", false)]
    [InlineData("(11) 3123-5678", false)]
    [InlineData("11 3123-5678", false)]
    [InlineData("11 3123 5678", false)]
    [InlineData("11 31235678", false)]
    public void ShouldGetIsMobile(string phone, bool expected)
    {
        Phone result = phone;

        Assert.Equal(
            expected: expected,
            actual: result.IsMobile
        );
    }

    # endregion

    # region ---- from split ---------------------------------------------------

    [Theory]
    [InlineData("11", "912345678", "11912345678")]
    [InlineData("11", "31235678", "1131235678")]
    public void ShouldCreateFromSplit(
        string ddd,
        string number,
        string expected
    )
    {
        var result = Phone.FromSplit(ddd, number);

        Assert.Equal(
            expected: expected,
            actual: result
        );
    }

    # endregion
}
