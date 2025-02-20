using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [Header("ui components")]
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Button _restartBtn;
    [SerializeField] private Button _goToMenuBtn;

    [Header("settings")]
    [SerializeField] private string _text;

    public void Start()
    {
        _restartBtn.onClick.AddListener(RestartPressed);
        _goToMenuBtn.onClick.AddListener(GoToMenuPressed);
    }
    public void Show(int score)
    {
        _scoreText.text = $"{_text} {score}";
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    private void RestartPressed()
    {
        GameManager.Instance.StartLevel();
        Hide();
    }
    private void GoToMenuPressed()
    {
        Debug.Log("go to menu logic");
        Hide();
    }
    
}
