using UnityEngine;

public class FlagsTrigger : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        Player player;
        if (other.TryGetComponent(out player))
        {
            _audioSource.Play();
            _animator.Play("Open");
        }
    }
}
