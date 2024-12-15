using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace RatingService;

[ApiController]
[Route("api/[controller]")]
public class RatingsController : ControllerBase
{
    private readonly RatingService _ratingService;
    private readonly ILogger<RatingsController>? _logger;

    public RatingsController(RatingService ratingService, ILogger<RatingsController> logger)
    {
        _ratingService = ratingService;
        _logger = logger;
    }

    [HttpPost]
    public IActionResult SubmitRating([FromBody] Rating rating)
    {
        if (rating == null || rating.Score < 0)
        {
            return BadRequest("Invalid rating data.");
        }

        try
        {
            _ratingService.AddRating(rating);
            _logger.LogInformation("Rating submitted: {Rating}", rating);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error submitting rating");
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }

    [HttpGet("{providerId}/average")]
    public IActionResult GetAverageRating(string providerId)
    {
        try
        {
            var average = _ratingService.GetAverageRating(providerId);
            return Ok(average);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching average rating for provider {ProviderId}", providerId);
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }
}