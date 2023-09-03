namespace MovieEnthusiast.Domain.Entities;

public class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public DateTime ReleasedOn { get; set; }
}
