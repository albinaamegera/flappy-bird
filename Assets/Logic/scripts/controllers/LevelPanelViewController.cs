using UnityEngine;

public class LevelPanelViewController : PanelViewController
{
    [Header("ui references")]
    [SerializeField] private ViewController _pauseController;
    [SerializeField] private CoinViewController _coinController;
    [SerializeField] private PointViewController _pointController;

    // event listeners
    private EventListener<OnPlayerCollision> _onPlayerCollisionEventListener = new();
    private EventListener<OnLevelRestartedEvent> _onLevelRestartedEventListener = new();
    private EventListener<OnDataInitialized> _onDataInitializedEventListener = new();
    private void Awake()
    {
        _onDataInitializedEventListener.Add(e => Initialize(e.persistentData));
    }
    private void OnEnable()
    {
        _onPlayerCollisionEventListener.Add(ShowController);
        _onLevelRestartedEventListener.Add(HideController);
    }
    private void Initialize(IPersistentData persistentData)
    {
        _coinController.Initialize(persistentData.PlayerData.Wallet);
        _pointController.Initialize(persistentData.PlayerData.ScoreCounter);
    }
    public override void Hide()
    {
        HideController();
        base.Hide();
    }
    private void ShowController() => _pauseController.Show();
    private void HideController() => _pauseController.Hide();
    private void OnDisable()
    {
        _onPlayerCollisionEventListener.Remove(ShowController);
        _onLevelRestartedEventListener.Remove(HideController);
        _onDataInitializedEventListener.Remove(e => Initialize(e.persistentData));
    }
}
