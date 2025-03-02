using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour 
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private Player _player;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _winAudio;
    [SerializeField] private AudioClip _loseAudio;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Win()
    {
        _audioSource.clip = _winAudio;
        _audioSource.Play();
        _player.OnWin();
        var koef = _player.Rating >= 140 ? 5 : _player.Rating >= 100 ? 4 : _player.Rating >= 70 ? 3 : _player.Rating >= 35 ? 2 : 1;
        _uiManager.ShowWinMenu(_player.Rating * koef);
    }

    public void Lose()
    {
        _audioSource.clip = _loseAudio;
        _audioSource.Play();
        _player.OnLose();
        _uiManager.ShowLoseMenu();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

