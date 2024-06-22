using Microsoft.EntityFrameworkCore;
using MovieEnthusiast.Application.Common.Interfaces;
using MovieEnthusiast.Domain.Entities;
using MovieEnthusiast.Infrastructure.Persistence;

namespace MovieEnthusiast.Infrastructure.Repositories;

public class GenericRepository<T>(ApplicationDbContext context) : IGenericRepository<T> where T : class, IEntity
{
    public async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken)
    {
        try
        {
            return await context.Set<T>().Select(all => all).ToListAsync(cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<int> Add(T entity, CancellationToken cancellationToken)
    {
        int identifier;
        try
        {
            await context.Set<T>().AddAsync(entity, cancellationToken);
            identifier = entity.Id!.Value;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return identifier;
    }
}