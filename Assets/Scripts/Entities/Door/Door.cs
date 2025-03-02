using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private int _needRating;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _animationName;
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        IHaveRating player;
        
        if (other.TryGetComponent(out player))
        {
            if (player.Rating >= _needRating)
            {
                OpenDoor();
            }
            else
            {
                GameManager.Instance.Win();
            }
        }
    }

    private void OpenDoor()
    {
        _animator.Play(_animationName);
        _audioSource.Play();
    }
}
