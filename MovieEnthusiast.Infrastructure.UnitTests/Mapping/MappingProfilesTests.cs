using AutoMapper;
using MovieEnthusiast.Infrastructure.Mapping;
using Xunit;

namespace MovieEnthusiast.Infrastructure.UnitTests.Mapping;

public class MappingProfilesTests
{
    [Fact]
    public void Validate_MappingProfiles()
    {
        // Arrange
        MapperConfiguration mapperConfig = new(
        cfg =>
        {
            cfg.AddMaps(new[] { typeof(MovieProfile) });
        });

        // Act & Assert
        mapperConfig.AssertConfigurationIsValid();
    }
}
