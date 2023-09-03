using Microsoft.EntityFrameworkCore;
using MovieEnthusiast.Domain.Entities;

namespace MovieEnthusiast.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Movie> Movies => Set<Movie>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Movie>()
            .ToTable("Movie");
    }
}
