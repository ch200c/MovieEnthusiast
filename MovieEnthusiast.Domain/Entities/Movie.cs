namespace MovieEnthusiast.Domain.Entities;

public class Movie : IEntity
{
    public int? Id { get; init; }
    
    public required string Title { get; init; }
}
