using AutoFixture;
using FluentAssertions;
using MovieEnthusiast.Application.Commands;
using MovieEnthusiast.Application.Common.Interfaces;
using MovieEnthusiast.Domain.Entities;
using NSubstitute;
using NUnit.Framework;

namespace MovieEnthusiast.Application.Tests.Commands;

[TestFixture]
public class AddMovieCommandHandlerTests
{
    private IGenericRepository<Movie> _movieRepositoryMock;
    private Fixture _fixture;
    private AddMovieCommandHandler _sut;
    private const int TestId = 12;

    [SetUp]
    public void SetUp()
    {
        _movieRepositoryMock = Substitute.For<IGenericRepository<Movie>>();
        _sut = new AddMovieCommandHandler(_movieRepositoryMock);
        _fixture = new Fixture();
    }

    [Test]
    public async Task ValidCommand_Handle_SavesEntityAndReturnsId()
    {
        // Arrange
        var command = _fixture.Create<AddMovieCommand>();
        _movieRepositoryMock.Add(Arg.Is<Movie>(x => x.Title ==command.movie.Title), Arg.Any<CancellationToken>()).Returns(TestId);

        // Act
        var result= await _sut.Handle(command, CancellationToken.None);

        // Assert
        result.Should().Be(TestId);
    }
}