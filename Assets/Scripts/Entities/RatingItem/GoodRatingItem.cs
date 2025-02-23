public class GoodRatingItem : RatingItem
{
    protected override void ChangeRatingTo(IHaveRating player)
    {
        player.IncreaseRating(Value);
        Destroy();
    }
}

