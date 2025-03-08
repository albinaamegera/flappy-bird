using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [Header("ui components")]
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _scoreNewRecordText;
    [SerializeField] private Button _restartBtn;
    [SerializeField] private Button _goToMenuBtn;

    public string message { get; set; }
    public string newRecordMessage { get; set; }

    public void Start()
    {
        _restartBtn.onClick.AddListener(RestartPressed);
        _goToMenuBtn.onClick.AddListener(GoToMenuPressed);
    }
    public void Show(int score)
    {
        if (PlayerManager.Instance.RecordDetected)
        {
            _scoreNewRecordText.gameObject.SetActive(true);
            _scoreNewRecordText.text = $"{newRecordMessage} : {score} !!";
            _scoreText.gameObject.SetActive(false);
            Debug.Log(newRecordMessage);
        }
        else
        {
            _scoreText.gameObject.SetActive(true);
            _scoreText.text = $"{message} : {score}";
            _scoreNewRecordText.gameObject.SetActive(false);
            Debug.Log(message);
        }
        _pausePanel.SetActive(true);
    }
    private void Hide()
    {
        _pausePanel.SetActive(false);
    }
    private void RestartPressed()
    {
        GameManager.Instance.StartLevel();
        Hide();
    }
    private void GoToMenuPressed()
    {
        GameManager.Instance.LoadScene("MenuScene");
    }
    
}
