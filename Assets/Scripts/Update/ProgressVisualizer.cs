using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ProgressVisualizer : MonoBehaviour
{
    [SerializeField] private Image _progressBar;
    [SerializeField] private TMP_Text _progressStageText;
    [SerializeField] private TMP_Text _ratingText;
    [SerializeField] private Animator _newStageAnimator;
    [SerializeField] private TMP_Text _newStageText;

    public void UpdateInfo(Color newColor, string newStageName)
    {
        _progressBar.color = newColor;
        _progressStageText.color = newColor;
        _progressStageText.text = newStageName;
    }

    public void UpdateBarFillAmount(float value)
    {
        _progressBar.fillAmount = value;
    }

    public void UpdateRatingCount(int value)
    {
        _ratingText.text = value.ToString();
    }

    public void OnNewStage(RatingConfig ratingConfig)
    {
        _newStageText.color = ratingConfig.Color;
        _newStageText.text = ratingConfig.Name;
        _newStageAnimator.SetTrigger("NewStage");
    }
}

