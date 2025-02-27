using TMPro;
using UnityEngine;

public class MoneyEffect : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private TMP_Text _text;

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
        _text.text = _currentMoney.ToString();
        _animator.SetTrigger("Increased");
    }

    public void DecreaseMoney(int value)
    {
        if (_isIncreased)
        {
            _currentMoney = value;
            _isIncreased = false;
        }
        else _currentMoney += value;

        _text.text = _currentMoney.ToString();
        _animator.SetTrigger("Decreased");
    }

    public void ResetMoneyCount()
    {
        _currentMoney = 0;
    }
}
