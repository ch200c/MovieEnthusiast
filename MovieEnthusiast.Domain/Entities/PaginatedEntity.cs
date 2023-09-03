namespace MovieEnthusiast.Domain.Entities;

public class PaginatedEntity<T>
{
    public IEnumerable<T> Items { get; init; } = new List<T>();

    public int? TotalItemCount { get; set; }
}