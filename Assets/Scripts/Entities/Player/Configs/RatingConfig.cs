using UnityEngine;
[CreateAssetMenu]
public class RatingConfig : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Color Color { get; private set; }
    [field: SerializeField] public AnimationClip WalkAnimation { get; private set; }
}
