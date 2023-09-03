namespace MovieEnthusiast.Application.Common.Models;

public class PaginatedList<T>
{
    public readonly IReadOnlyCollection<T> Items;

    public int PageNumber { get; }

    public int? TotalPages { get; }

    public int? TotalCount { get; }

    public PaginatedList(IReadOnlyCollection<T> items, int pageNumber, int pageSize, int? totalCount)
    {
        Items = items;
        PageNumber = pageNumber;
        TotalPages = totalCount != null ? (int)Math.Ceiling(totalCount.Value / (double)pageSize) : null;
        TotalCount = totalCount;
    }
}