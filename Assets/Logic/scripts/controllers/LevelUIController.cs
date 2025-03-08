using TMPro;
using UnityEngine;

public class LevelUIController : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _coinText;
    [SerializeField] private PauseMenuController _controller;

    [Header("settings")]
    [SerializeField] private Timer _timer;

    private int _currentScore;

    private void Start()
    {
        GameManager.Instance.OnScoreAdded += UpdateScoreText;
        GameManager.Instance.OnCoinCollected += UpdateCoinText;
        GameManager.Instance.OnGameOver += _timer.StartTimer;
        _timer.OnTimerComplete.AddListener(ShowGameOverPanel);
        UpdateCoinText(PlayerManager.Instance.DataCoins);
    }
    private void UpdateScoreText(int value)
    {
        _currentScore = value;
        _scoreText.text = value.ToString();
    }
    private void UpdateCoinText(int value)
    {
        _coinText.text = value.ToString();
    }
    private void ShowGameOverPanel()
    {
        _controller.Show(_currentScore);
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnScoreAdded -= UpdateScoreText;
        GameManager.Instance.OnCoinCollected -= UpdateCoinText;
        GameManager.Instance.OnGameOver -= _timer.StartTimer;
    }
}
