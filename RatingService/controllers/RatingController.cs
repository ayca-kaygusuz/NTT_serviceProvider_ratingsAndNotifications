namespace RatingService.controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RatingsController : ControllerBase
{
    private readonly RatingService _ratingService;

    public RatingsController(RatingService ratingService)
    {
        _ratingService = ratingService;
    }

    [HttpPost]
    public IActionResult SubmitRating([FromBody] Rating rating)
    {
        _ratingService.AddRating(rating);
        return Ok();
    }

    [HttpGet("{providerId}/average")]
    public IActionResult GetAverageRating(string providerId)
    {
        var average = _ratingService.GetAverageRating(providerId);
        return Ok(average);
    }
}