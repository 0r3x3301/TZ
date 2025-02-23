using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour 
{
    [SerializeField] private GameObject _startUI;
    [SerializeField] private GameObject _inGameUI;
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private TMP_Text _winMoneyText;
    [SerializeField] private GameObject _loseMenu;
    [SerializeField] private GameObject _playerUI;

    private static UIManager _instance;

    private void Awake()
    {
        _instance = this;
        _playerUI.SetActive(false);
    }

    public static UIManager GetInstance()
    {
        return _instance;
    }

    public void ShowWinMenu(int moneyCount)
    {
        HideAll();
        _winMoneyText.text += " " + moneyCount;
        _winMenu.SetActive(true);
        _playerUI.SetActive(false);
    }

    public void ShowLoseMenu()
    {
        HideAll();
        _loseMenu.SetActive(true);
        _playerUI.SetActive(false);
    }

    public void HideAll()
    {
        _startUI.SetActive(false);
        _winMenu.SetActive(false);
        _loseMenu.SetActive(false);
        _inGameUI.SetActive(false);
    }

    public void HideStartUI()
    {
        _startUI.SetActive(false);
        _playerUI.SetActive(true);
    }

    public void ShowStartUI()
    {
        HideAll();
        _startUI.SetActive(true);
        _playerUI.SetActive(false);
    }
    
    public void HideInGameUI()
    {
        _inGameUI.SetActive(false);
        _playerUI.SetActive(false);
    }

    public void ShowInGameUI()
    {
        HideAll();
        _inGameUI.SetActive(true);
        _playerUI.SetActive(true);
    }
}