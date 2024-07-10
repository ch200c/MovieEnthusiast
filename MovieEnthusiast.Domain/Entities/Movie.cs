using MovieEnthusiast.Domain.Data;

namespace MovieEnthusiast.Domain.Entities;

public class Movie : Entity
{
    public required string Title { get; set; }
}
