namespace RatingService.models;

public class Rating
{
    public int Id { get; set; }
    public string ProviderId { get; set; }
    public double Score { get; set; }
}