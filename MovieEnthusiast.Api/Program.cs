using Microsoft.EntityFrameworkCore;
using MovieEnthusiast.Application.Common.Interfaces;
using MovieEnthusiast.Application.Queries;
using MovieEnthusiast.Infrastructure.Persistence;
using MovieEnthusiast.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(
    c => c.RegisterServicesFromAssembly(typeof(GetMoviesQuery).Assembly));

builder.Services.AddTransient<IMovieRepository, MovieRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Sql")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
