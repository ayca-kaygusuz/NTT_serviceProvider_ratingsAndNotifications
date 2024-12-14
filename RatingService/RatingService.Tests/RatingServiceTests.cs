namespace RatingService.RatingService.Tests;

using Xunit;

public class RatingServiceTests
{
    private readonly RatingService _ratingService;

    public RatingServiceTests()
    {
        _ratingService = new RatingService();
    }

    [Fact]
    public void AddRating_ShouldAddRating()
    {
        // Arrange
        var rating = new Rating { Id = 1, ProviderId = "provider123", Score = 5.0 };

        // Act
        _ratingService.AddRating(rating);

        // Assert
        var average = _ratingService.GetAverageRating("provider123");
        Assert.Equal(5.0, average);
    }

    [Fact]
    public void GetAverageRating_NoRatings_ReturnsZero()
    {
        // Act
        var average = _ratingService.GetAverageRating("provider123");

        // Assert
        Assert.Equal(0, average);
    }

    [Fact]
    public void GetAverageRating_MultipleRatings_CorrectAverage()
    {
        // Arrange
        _ratingService.AddRating(new Rating { Id = 1, ProviderId = "provider123", Score = 5.0 });
        _ratingService.AddRating(new Rating { Id = 2, ProviderId = "provider123", Score = 3.0 });

        // Act
        var average = _ratingService.GetAverageRating("provider123");

        // Assert
        Assert.Equal(4.0, average);
    }
}