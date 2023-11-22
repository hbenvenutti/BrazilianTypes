using System.Diagnostics.CodeAnalysis;
using BrazilianTypes.Exceptions;
using BrazilianTypes.Types;

namespace Test.Types;

[ExcludeFromCodeCoverage]
public class EmailTest
{
    [Theory]
    [InlineData("foobar@gmail.com", "foobar@gmail.com")]
    [InlineData("FOOBAR@GMAIL.COM", "foobar@gmail.com")]
    [InlineData(" foobar@gmail.com ", "foobar@gmail.com")]
    [InlineData("foobar@example.com.br", "foobar@example.com.br")]
    [InlineData("foo.bar@gmail.com", "foo.bar@gmail.com")]
    [InlineData("foobar+10@gmail.com", "foobar+10@gmail.com")]
    [InlineData("foobar+10@gmail.com.br", "foobar+10@gmail.com.br")]
    [InlineData("foo_bar@gmail.com", "foo_bar@gmail.com")]
    public void ShouldCreateAnEmail(string email, string expected)
    {
        Email result = email;

        Assert.Equal(
            expected: expected,
            actual: result
        );
    }

    [Theory]
    [InlineData("foobar@Gmail")]
    [InlineData(".foobar@Gmail.com")]
    [InlineData("foobar.gmail")]
    [InlineData("foobar@gmail.")]
    [InlineData("foobar@gmail..com")]
    [InlineData("foobar.gmail.com")]
    [InlineData("foobar@gmailcom")]
    [InlineData("foobar@.gmail.com")]
    [InlineData("foobar_gmail.com")]
    [InlineData("foobar gmail.com")]
    [InlineData("foobar@gmail com")]
    [InlineData("foobar@gmail. com")]
    [InlineData("foobar@gmail. com.br")]
    [InlineData("foobar@gmail. com. br")]
    [InlineData("foobar@gmail. com .br")]
    [InlineData("foobar@gmail. com . br")]
    [InlineData("@gmail.com")]
    [InlineData("@")]
    [InlineData("foobar")]
    [InlineData("foobar@")]
    [InlineData("foobar@gmail")]
    [InlineData("foobar@gmail..")]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void ShouldThrowAnExceptionWhenEmailIsInvalid(string email)
    {
        Assert.Throws<InvalidValueException>(() => { Email _ = email;});
    }
}
