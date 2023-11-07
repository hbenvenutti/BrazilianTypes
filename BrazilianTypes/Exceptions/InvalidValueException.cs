namespace BrazilianTypes.Exceptions;

internal class InvalidValueException : ArgumentException
{
    public InvalidValueException(
        string message,
        string value,
        string? paramName = null,
        Exception? innerException = null
    )
        : base(message: $"{message}: {value}", paramName, innerException)
    {
    }
}
