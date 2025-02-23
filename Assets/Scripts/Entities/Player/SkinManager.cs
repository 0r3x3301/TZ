using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private GameObject _poorSkin;
    [SerializeField] private GameObject _casualSkin;
    [SerializeField] private GameObject _middleSkin;
    [SerializeField] private GameObject _richSkin;
    [SerializeField] private GameObject _millionerSkin;

    public RatingConfig.Skin CurrentSkin { get; private set; }
    public event System.Action SkinChanged;

    public void SetSkin(RatingConfig.Skin skin)
    {
        CurrentSkin = skin;
        _poorSkin.SetActive(skin == RatingConfig.Skin.Poor);
        _casualSkin.SetActive(skin == RatingConfig.Skin.Casual);
        _middleSkin.SetActive(skin == RatingConfig.Skin.Middle);
        _richSkin.SetActive(skin == RatingConfig.Skin.Rich);
        _millionerSkin.SetActive(skin == RatingConfig.Skin.Millioner);
        SkinChanged?.Invoke();
    }
}