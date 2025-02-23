using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private RatingConfig.Skin _needSkin;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _animationName;
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        SkinManager playerSkinManager;
        
        if (other.TryGetComponent(out playerSkinManager))
        {
            if (playerSkinManager.CurrentSkin >= _needSkin)
            {
                OpenDoor();
            }
            else
            {
                GameManger.Instance.Win();
            }
        }
    }

    private void OpenDoor()
    {
        _animator.Play(_animationName);
        _audioSource.Play();
    }
}
