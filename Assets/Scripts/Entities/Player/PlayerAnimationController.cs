using UnityEditor.Animations;
using UnityEngine;
public class PlayerAnimationController : MonoBehaviour 
{
    [SerializeField] private Animator _animator;

    public void PlayWalking()
    {
        _animator.SetBool("IsWalking", true);
    }

    public void PlayWin()
    {
        _animator.SetBool("IsWalking", false);
        _animator.SetTrigger("Win");
    }

    public void PlayLose()
    {
        _animator.SetBool("IsWalking", false);
        _animator.SetTrigger("Lose");
    }

    public void OnNewStage(RatingConfig ratingConfig)
    {
        _animator.SetTrigger("NewStage");
    }

    public void Hit()
    {
        _animator.SetTrigger("Hit");
    }

    public void OnRatingChanged(int value)
    {
        _animator.SetFloat("Rating", value);
    }
}

