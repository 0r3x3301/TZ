using UnityEngine;
public abstract class RatingItem : MonoBehaviour
{
    [field: SerializeField] public int Value { get; protected set; }

    private void OnTriggerEnter(Collider other)
    {
        IHaveRating player;
        if (other.TryGetComponent(out player))
        {
            ChangeRatingTo(player);
        }
    }

    protected void Destroy()
    {
        Destroy(gameObject);
    }

    protected abstract void ChangeRatingTo(IHaveRating player);
}

