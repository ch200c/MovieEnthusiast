using Microsoft.EntityFrameworkCore;
using MovieEnthusiast.Domain.Entities;

namespace MovieEnthusiast.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Movie>()
            .ToTable("Movie");
    }
}
