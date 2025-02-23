public class BadRatingItem : RatingItem
{
    protected override void ChangeRatingTo(IHaveRating player)
    {
        player.DecreaseRating(Value);
        Destroy();
    }
}

