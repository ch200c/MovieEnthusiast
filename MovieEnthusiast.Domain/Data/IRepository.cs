namespace MovieEnthusiast.Domain.Data;

public interface IRepository
{
    IUnitOfWork UnitOfWork { get; }
}