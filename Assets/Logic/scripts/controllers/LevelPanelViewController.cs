using UnityEngine;

public class LevelPanelViewController : ViewController
{
    [Header("ui references")]
    [field : SerializeField] private ViewController _pauseController;

    // event listeners
    private EventListener<OnPlayerCollision> _onPlayerCollisionEventListener = new();
    private EventListener<OnLevelRestartedEvent> _onLevelRestartedEventListener = new();
    private void Awake()
    {
        _onPlayerCollisionEventListener.Add(ShowController);
        _onLevelRestartedEventListener.Add(HideController);
    }
    public override void Hide()
    {
        base.Hide();
    }

    public override void Show()
    {
        base.Show();
    }
    private void ShowController() => _pauseController.Show();
    private void HideController() => _pauseController.Hide();
}
