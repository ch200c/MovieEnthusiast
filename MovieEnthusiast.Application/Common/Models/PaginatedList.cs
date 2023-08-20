namespace MovieEnthusiast.Application.Common.Models;

public class PaginatedList<T>
{
    public readonly IReadOnlyCollection<T> Items;

    public int PageNumber { get; }

    public int TotalPages { get; }

    public int TotalCount { get; }

    public PaginatedList(IReadOnlyCollection<T> items, int count, int pageSize)
    {
        PageNumber = count;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        Items = items;
    }

}
