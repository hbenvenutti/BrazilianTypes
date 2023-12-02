using System.Net;

namespace Benvenutti.Lib.Responses;

public interface IHandlerResponse<T, TAppStatusCode>
    where TAppStatusCode : Enum
{
    bool IsSuccess { get; init; }
    HttpStatusCode HttpStatusCode { get; init; }
    TAppStatusCode AppStatusCode { get; init; }
    T? Data { get; init; }
    List<string>? Errors { get; init; }
}
