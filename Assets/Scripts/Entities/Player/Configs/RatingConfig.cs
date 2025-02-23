using UnityEngine;
[CreateAssetMenu]
public class RatingConfig : ScriptableObject
{
    [field: SerializeField] public Color BarColor { get; private set; }
    [field: SerializeField] public string ModelName { get; private set; }
    [field: SerializeField] public string WalkAnimationName { get; private set; }
    [field: SerializeField] public Skin SkinType { get; private set; }
    public enum Skin
    {
        Poor = 0,
        Casual = 1,
        Middle = 2,
        Rich = 3,
        Millioner = 4
    }
}

