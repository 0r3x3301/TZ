using UnityEngine;
public class AnimationController : MonoBehaviour 
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SkinManager _skinManager;
    [SerializeField] private Player _player;

    private string _currentWalkingAnimation = "SadWalking";

    public void PlayWalking()
    {
        _animator.Play(_currentWalkingAnimation);
    }

    public void PlayWin()
    {
        _animator.Play("Win");
    }

    public void PlayLose()
    {
        _animator.Play("Lose");
    }

    public void PlayIdle()
    {
        _animator.Play("Idle");
    }

    private void OnSkinChanged()
    {
        switch (_skinManager.CurrentSkin)
        {
            case RatingConfig.Skin.Poor:
            case RatingConfig.Skin.Casual:
                _currentWalkingAnimation = "SadWalking";
                break;

            case RatingConfig.Skin.Middle:
                _currentWalkingAnimation = "Walking";
                break;
            case RatingConfig.Skin.Rich:
                _currentWalkingAnimation = "RichWalking";
                break;
            case RatingConfig.Skin.Millioner:
                _currentWalkingAnimation = "MillionerWalking";
                break;
        }
        if (_player.IsMoving) PlayWalking();
    }

    private void OnEnable()
    {
        _skinManager.SkinChanged += OnSkinChanged;
    }


    private void OnDisable()
    {
        _skinManager.SkinChanged -= OnSkinChanged;
    }
}

