namespace RatingService;

public class Rating
{
    public int Id { get; set; }
    public required string ProviderId { get; set; }
    public double Score { get; set; }
}