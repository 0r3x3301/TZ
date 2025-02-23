using UnityEngine;

[System.Serializable]
public class RatingState
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public int NeedRating { get; private set; }
    [field: SerializeField] public RatingConfig Config { get; private set; }
}
