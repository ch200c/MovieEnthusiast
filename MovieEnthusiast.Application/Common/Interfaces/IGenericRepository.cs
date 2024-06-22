using MovieEnthusiast.Domain.Entities;

namespace MovieEnthusiast.Application.Common.Interfaces;

public interface IGenericRepository<T> where T : IEntity
{
    Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);
    Task<int> Add(T entity, CancellationToken cancellationToken);
}