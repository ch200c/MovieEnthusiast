namespace MovieEnthusiast.Api.Requests;

public class PaginatedRequest
{
    private const int DefaultPageNumber = 1;

    private const int DefaultPageSize = 50;

    public int? PageNumber { get; } = DefaultPageNumber;

    public int? PageSize { get; } = DefaultPageSize;

    public bool? ReturnTotalItemCount { get; }
}