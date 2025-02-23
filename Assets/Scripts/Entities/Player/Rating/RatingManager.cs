using System.Linq;
using System.Runtime.CompilerServices;
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

    private RatingState _currentRatingState;
    private IHaveRating _player;

    public void Init()
    {
        _player = GetComponent<IHaveRating>();
    }

    public void RatingDecreased()
    {
        _audioSource.clip = _badItemAudio;
        _audioSource.Play();
        UpdateBar();
        if (_player.Rating > 0)
        {
            UpdateInfo();
        }
        else
        {
            GameManger.Instance.Lose();
        }
    }

    public void RatingIncreased()
    {
        _audioSource.clip = _goodItemAudio;
        _audioSource.Play();
        UpdateInfo();
        UpdateBar();
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
        _skinManager.SetSkin(rating.Config.SkinType);
    }
}
