using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class RatingList 
{
    [field: SerializeField] public List<RatingState> Ratings { get; private set; }
}

