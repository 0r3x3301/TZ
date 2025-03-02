using System.Linq;
using UnityEngine;

public class RatingManager : MonoBehaviour 
{
    [SerializeField] private int _maxRating = 140;
    [SerializeField] private RatingList _ratingList;
    [SerializeField] private AudioClip _goodItemAudio;
    [SerializeField] private AudioClip _badItemAudio;
    [SerializeField] private SkinSelector _skinSelector;
    [SerializeField] private RatingEffectController _ratingEffectController;
    [SerializeField] private ProgressVisualizer _progressVisualizer;
    [SerializeField] private Player Player;
    [SerializeField] private PlayerAnimationController _playerAnimationController;
    [SerializeField] private RotaterAround _playerRotater;

    private RatingState _currentRatingState;
    private IHaveRating _player;

    private void Awake()
    {
        Init(Player);
    }

    public void Init(IHaveRating player)
    {
        _player = player;
        _currentRatingState = _ratingList.Ratings.OrderBy(x => x.NeedRating).ToList()[1];
        _progressVisualizer.UpdateInfo(_currentRatingState.Config.Color, _currentRatingState.Config.Name);
    }

    public void RatingDecreased(int value)
    {
        if (value > 0)
        {
            _ratingEffectController.DecreaseMoney(value);
            SoundManager.GetInstance().Play(_badItemAudio);
        }
        
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
        if (value > 0)
        {
            _ratingEffectController.IncreaseMoney(value);
            SoundManager.GetInstance().Play(_goodItemAudio);
        }
        
        UpdateBar();
        if (value > 0) UpdateInfo();
    }

    public void UpdateInfo()
    {
        _progressVisualizer.UpdateRatingCount(_player.Rating);
        var ratings = _ratingList.Ratings.Where(x => x.NeedRating <= _player.Rating)?.OrderBy(x => x.NeedRating);
        var avaibleRating = ratings.Last();
        if (avaibleRating != _currentRatingState)
        {
            if (_currentRatingState.NeedRating < avaibleRating.NeedRating)
            {
                _progressVisualizer.OnNewStage(avaibleRating.Config);
                _playerAnimationController.OnNewStage(avaibleRating.Config);
                _playerRotater.StartRotate();
            }
            else
            {
                _playerAnimationController.Hit();
            }
            _progressVisualizer.UpdateInfo(avaibleRating.Config.Color, avaibleRating.Config.Name);
            _skinSelector.SetSkin(avaibleRating.Config);
            _currentRatingState = avaibleRating;
        }
    }

    public void UpdateBar()
    {
        _progressVisualizer.UpdateBarFillAmount((float)_player.Rating / (float)_maxRating);
        _playerAnimationController.OnRatingChanged(_player.Rating);
    }

    private void OnEnable()
    {
        _player.RatingIncreased += RatingIncreased;
        _player.RatingDecreased += RatingDecreased;
    }
    
    private void OnDisable()
    {
        _player.RatingIncreased -= RatingIncreased;
        _player.RatingDecreased -= RatingDecreased;
    }
}
