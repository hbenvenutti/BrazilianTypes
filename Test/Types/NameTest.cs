using System.Diagnostics.CodeAnalysis;
using BrazilianTypes.Exceptions;
using BrazilianTypes.Types;

namespace Test.Types;

[ExcludeFromCodeCoverage]
public class NameTest
{
    [Theory]
    [InlineData("John Doe", "John Doe")]
    [InlineData("John Doe Jr", "John Doe Jr")]
    [InlineData("John Doe Jr ", "John Doe Jr")]
    [InlineData("John Doe Jr  ", "John Doe Jr")]
    [InlineData(" John Doe Jr", "John Doe Jr")]
    [InlineData("João", "João")]
    [InlineData("Júlia", "Júlia")]
    public void ShouldParseName(string value, string expected)
    {
        Name name = value;

        Assert.Equal(expected, actual: name);
    }

    [Theory]
    [InlineData("A")]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    [InlineData("123")]
    [InlineData("John Doe 123")]
    [InlineData("John Doe Jr 123")]
    [InlineData("@#$")]
    [InlineData("John Doe Jr @#$")]
    [InlineData("John Doe Jr @#$ 123")]
    public void ShouldNotParseName(string value)
    {
        Assert.Throws<InvalidValueException>(() => { Name _ = value; });
    }
}
