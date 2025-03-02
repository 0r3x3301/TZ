using UnityEngine;
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private static SoundManager _instance;

    private void Awake()
    {
        _instance = this;
    }

    public static SoundManager GetInstance()
    {
        return _instance;
    }

    public void Play(AudioClip clip, float pitch = 1)
    {
        _audioSource.clip = clip;
        _audioSource.pitch = pitch;
        _audioSource.Play();
    }

    public void StopPlay()
    {
        _audioSource.Stop();
    }
}

