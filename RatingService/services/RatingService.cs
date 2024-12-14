namespace RatingService.services;

using System.Collections.Generic;
using System.Linq;

public class RatingService
{
    private readonly List<Rating> _ratings = new();

    public void AddRating(Rating rating)
    {
        _ratings.Add(rating);
        // Example: Notify Notification Service
        // NotifyNotificationService(rating);
    }

    public double GetAverageRating(string providerId)
    {
        var providerRatings = _ratings.Where(r => r.ProviderId == providerId).ToList();
        return providerRatings.Count > 0 ? providerRatings.Average(r => r.Score) : 0;
    }
}