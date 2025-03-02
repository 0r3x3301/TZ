using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    [SerializeField] private List<SkinVariant> _skins;

    public void SetSkin(RatingConfig ratingConfig)
    {
        foreach (var skin in _skins)
        {
            if (skin.Name != ratingConfig.Name) skin.Model.SetActive(false);
            else skin.Model.SetActive(true);
        }
    }
}