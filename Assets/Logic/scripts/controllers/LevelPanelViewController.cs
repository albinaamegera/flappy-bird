using UnityEngine;

public class LevelPanelViewController : PanelViewController
{
    [Header("ui references")]
    [SerializeField] private PauseViewController _pauseController;
    [SerializeField] private CoinViewController _coinController;
    [SerializeField] private PointViewController _pointController;

    IPersistentData _persistentData;

    // event listeners
    private EventListener<OnPlayerCollision> _onPlayerCollisionEventListener = new();
    private EventListener<OnLevelRestartedEvent> _onLevelRestartedEventListener = new();
    
    private void OnEnable()
    {
        _onPlayerCollisionEventListener.Add(ShowController);
        _onLevelRestartedEventListener.Add(HideController);
    }
    public void Initialize(IPersistentData persistentData)
    {
        _persistentData = persistentData;
        _coinController.Initialize(_persistentData.PlayerData.Wallet);
        _pointController.Initialize(_persistentData.PlayerData.ScoreCounter);
    }
    public override void Hide()
    {
        HideController();
        base.Hide();
    }
    private void ShowController() => _pauseController.Show(_persistentData.PlayerData.ScoreCounter.IsRecord());
    private void HideController() => _pauseController.Hide();
    private void OnDisable()
    {
        _onPlayerCollisionEventListener.Remove(ShowController);
        _onLevelRestartedEventListener.Remove(HideController);
    }
}
