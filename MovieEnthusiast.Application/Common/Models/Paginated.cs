namespace MovieEnthusiast.Application.Common.Models;

public class Paginated<T>
{
    public IEnumerable<T> Items { get; set; } = new List<T>();

    public int? TotalItemCount { get; set; }
}
