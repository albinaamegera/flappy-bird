using UnityEngine;

public class LevelPanelViewController : PanelViewController
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
        HideController();
        base.Hide();
    }
    private void ShowController() => _pauseController.Show();
    private void HideController() => _pauseController.Hide();
}
