public interface IHaveRating
{
    public int Rating { get; }
    public void IncreaseRating(int value);
    public void DecreaseRating(int value);
    public event System.Action<int> RatingIncreased;
    public event System.Action<int> RatingDecreased;
}
