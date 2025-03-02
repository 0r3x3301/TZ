using UnityEngine;

[System.Serializable]
public class SkinVariant
{
    [SerializeField] private RatingConfig _config;
    [field: SerializeField] public GameObject Model { get; private set; }

    public string Name => _config.Name;
}

