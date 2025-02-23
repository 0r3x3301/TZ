using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManger : MonoBehaviour 
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private Player _player;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _winAudio;
    [SerializeField] private AudioClip _loseAudio;

    public static GameManger Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Win()
    {
        _audioSource.clip = _winAudio;
        _audioSource.Play();
        _player.OnWin();
        _uiManager.ShowWinMenu(_player.Rating * ((int)_player.GetComponent<SkinManager>().CurrentSkin + 1));
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

