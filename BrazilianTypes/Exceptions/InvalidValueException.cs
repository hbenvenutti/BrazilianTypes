namespace BrazilianTypes.Exceptions;

/// <inheritdoc />
public class InvalidValueException : ArgumentException
{
    /// <inheritdoc />
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
