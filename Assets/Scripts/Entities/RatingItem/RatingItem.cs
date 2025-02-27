using UnityEngine;
public abstract class RatingItem : MonoBehaviour
{
    [field: SerializeField] public int Value { get; protected set; }

    protected Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.Rotate(0, 5 * Time.deltaTime, 0);
    }

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

