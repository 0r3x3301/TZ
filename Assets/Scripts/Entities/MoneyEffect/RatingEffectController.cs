using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RatingEffectController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private ParticleSystem _goodParticleSystem;
    [SerializeField] private ParticleSystem _badParticleSystem;
    [SerializeField] private Animator _moneyEffectAnimator;
    [SerializeField] private Image _moneyEffectImage;

    private int _currentMoney = 0;
    private bool _isIncreased;

    private void Awake()
    {
        _animator.StopPlayback();
    }

    public void IncreaseMoney(int value)
    {
        if (!_isIncreased)
        {
            _isIncreased = true;
            _currentMoney = value;
        }
        else _currentMoney += value;
        _text.text = "+ " + _currentMoney.ToString() + " $";
        _animator.SetTrigger("Increased");
        PlayPlayerEffect(true);
    }

    public void DecreaseMoney(int value)
    {
        if (_isIncreased)
        {
            _currentMoney = value;
            _isIncreased = false;
        }
        else _currentMoney += value;

        _text.text = "+ " + _currentMoney.ToString() + " $";
        _animator.SetTrigger("Decreased");
        PlayPlayerEffect(false);
    }

    public void ResetMoneyCount()
    {
        _currentMoney = 0;
    }

    private void PlayPlayerEffect(bool isGood)
    {
        if (isGood)
        {
            _goodParticleSystem.Play();
            _moneyEffectImage.color = Color.green;
        }
        else
        {
            _badParticleSystem.Play();
            _moneyEffectImage.color = Color.red;
        }
        _moneyEffectAnimator.SetTrigger("Play");
    }

}
