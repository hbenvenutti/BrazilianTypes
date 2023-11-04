namespace BrazilianTypes.Interfaces;

/// <summary>
/// Represents a specification that can be used to validate a type.
/// </summary>
/// <typeparam name="TCode">Code that represents your application error</typeparam>
/// <typeparam name="TType">Data to be validated.</typeparam>
public interface ISpecification<TCode, in TType>
    where TCode : struct, IType<TType>
    where TType : struct
{
    /// <summary>
    /// Gets the code that represents your application error.
    /// </summary>
    TCode Code { get; protected set; }

    /// <summary>
    /// Gets the error messages associated with the specification.
    /// </summary>
    ICollection<string> ErrorMessages { get; init; }

    /// <summary>
    /// Method that validates the data.
    /// </summary>
    /// <param name="data">Data to be validated</param>
    /// <returns>True if the data is valid; otherwise, False.</returns>
    bool IsSatisfiedBy(TType data);
}
