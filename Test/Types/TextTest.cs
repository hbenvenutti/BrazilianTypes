using System.Diagnostics.CodeAnalysis;
using BrazilianTypes.Exceptions;
using BrazilianTypes.Types;

namespace Test.Types;

[ExcludeFromCodeCoverage]
public class TextTest
{
    [Theory]
    [InlineData("Hello World", "Hello World")]
    [InlineData("  Hello World  ", "Hello World")]
    [InlineData("  Hello World", "Hello World")]
    [InlineData("Hello World  ", "Hello World")]
    public void Parse_ShouldReturnText_WhenValidValue(string value, string expected)
    {
        Text text = value;

        Assert.Equal(expected, actual:text);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Parse_ShouldThrowArgumentException_WhenInvalidValue(string value)
    {
        Assert.Throws<InvalidValueException>(() =>
        {
            Text _ = value;
        });
    }
}
