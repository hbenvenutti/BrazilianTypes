namespace Benvenutti.Lib.Responses;

public interface IPagedResponse
{
    uint Page { get; init; }
    uint PageSize { get; init; }
    uint TotalRecords { get; init; }
}
