using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieEnthusiast.Api.Controllers;
using MovieEnthusiast.Application.Common.Models;
using MovieEnthusiast.Application.Common.Requests;
using MovieEnthusiast.Application.Movies.Queries;
using MovieEnthusiast.Infrastructure.Mapping;
using NSubstitute;
using Xunit;

namespace MovieEnthusiast.Api.UnitTests.Controllers;

public class MovieControllerTests
{
    IMapper _mapper;
    IMediator _mediator = Substitute.For<IMediator>();
    MovieController _sut;

    public MovieControllerTests()
    {
        MapperConfiguration mapperConfig = new(
        cfg =>
        {
            cfg.AddProfile(new MovieProfile());
            cfg.AddProfile(new PaginationPofile());
        });

        _mapper = new Mapper(mapperConfig);
        _sut = new MovieController(_mapper, _mediator);
    }

    [Fact]
    public async Task Get_ValidaData_ReturnOkResult()
    {
        // Arrange
        const int PageNumber = 1;
        const int PageSize = 50;
        const int TotalCount = 3;

        const int ExpectedTotalPages = 1;

        const int Id = 12;
        const string Title = "Trapper";
        var ReleasedOn = DateTime.UtcNow;

        var movie = new MovieDto(Id, Title, ReleasedOn);
        var paginatedMovies = new PaginatedList<MovieDto>(new List<MovieDto> { movie }, PageNumber, PageSize, TotalCount);

        _mediator.Send(Arg.Any<GetMoviesQuery>(), CancellationToken.None)
            .Returns(paginatedMovies);

        var request = new GetMoviesRequest();

        // Act
        var actionResult = await _sut.Get(request, CancellationToken.None);
        var result = (PaginatedList<MovieDto>) ((OkObjectResult)actionResult.Result!).Value!;

        // Assert
        Assert.True(result.Items.First().Equals(movie));
        Assert.True(result.PageNumber == PageNumber);
        Assert.True(result.TotalPages == ExpectedTotalPages);
        Assert.True(result.TotalCount == TotalCount);
    }
}
