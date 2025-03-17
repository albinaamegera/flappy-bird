using UnityEngine;

public class PanelHolder : MonoBehaviour
{
    [Header("main panels")]
    [SerializeField] private PanelViewController _menuPanel;
    [SerializeField] private PanelViewController _levelPanel;

    // event listeners
    private EventListener<OnGameStartedEvent> _onGameStartedEventListener = new();
    private EventListener<OnLevelStartedEvent> _onLevelStartedEventListener = new();
    private EventListener<OnLevelExitEvent> _onLevelExitEventListener = new();

    private void Awake()
    {
        _onGameStartedEventListener.Add(ShowMenuPanel);
        _onLevelStartedEventListener.Add(ShowLevelPanel);
        _onLevelExitEventListener.Add(ShowMenuPanel);
    }
    private void ShowLevelPanel()
    {
        _menuPanel.Hide();
        _levelPanel.Show();
    }
    private void ShowMenuPanel()
    {
        _levelPanel.Hide();
        _menuPanel.Show();
    }
}
