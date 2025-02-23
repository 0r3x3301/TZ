public interface IHaveRating
{
    public int Rating { get; }
    public void IncreaseRating(int value);
    public void DecreaseRating(int value);
}
