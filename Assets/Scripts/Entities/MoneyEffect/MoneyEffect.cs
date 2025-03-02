using UnityEngine;

public class MoneyEffect : MonoBehaviour
{
    [SerializeField] private RatingEffectController _controller;
    public void ResetMoneyCount()
    {
        _controller.ResetMoneyCount();
    }
}
