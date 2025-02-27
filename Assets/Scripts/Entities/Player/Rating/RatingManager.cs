using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RatingManager : MonoBehaviour 
{
    [SerializeField] private int _maxRating = 140;
    [SerializeField] private RatingList _ratingList;
    [SerializeField] private Image _bar;
    [SerializeField] private TMP_Text _stateName;
    [SerializeField] private TMP_Text _ratingText;
    [SerializeField] private SkinManager _skinManager;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _goodItemAudio;
    [SerializeField] private AudioClip _badItemAudio;
    [SerializeField] private MoneyEffect _moneyEffect;

    private RatingState _currentRatingState;
    private IHaveRating _player;

    public void Init()
    {
        _player = GetComponent<IHaveRating>();
    }

    public void RatingDecreased(int value)
    {
        _moneyEffect.DecreaseMoney(value);
        _audioSource.clip = _badItemAudio;
        _audioSource.Play();
        UpdateBar();
        if (_player.Rating > 0)
        {
            UpdateInfo();
        }
        else
        {
            GameManager.Instance.Lose();
        }
    }

    public void RatingIncreased(int value)
    {
        _moneyEffect.IncreaseMoney(value);
        _audioSource.clip = _goodItemAudio;
        _audioSource.Play();
        UpdateBar();
        UpdateInfo();
    }

    public void UpdateBar()
    {
        _bar.fillAmount = (float)_player.Rating / (float)_maxRating;
    }

    public void UpdateInfo()
    {
        _ratingText.text = _player.Rating.ToString();
        var avaibleRating = _ratingList.Ratings.Where(x => x.NeedRating < _player.Rating)?.OrderBy(x => x.NeedRating)?.Last();

        if (avaibleRating != _currentRatingState)
        {
            UpdateRatingTo(avaibleRating);
        }
    }

    public void UpdateRatingTo(RatingState rating)
    {
        _currentRatingState = rating;
        _stateName.text = rating.Name;
        _stateName.color = rating.Config.BarColor;
        _bar.color = rating.Config.BarColor;
        _skinManager.SetSkin(rating.Config.SkinType);
    }
}
