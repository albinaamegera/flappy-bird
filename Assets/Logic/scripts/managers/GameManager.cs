using UnityEngine;

public class GameManager : MonoBehaviour
{
    private IDataManager _playerDataManager;
    // event listeners
    private EventListener<OnGameExitEvent> _onGameExitEventListener = new();
    private void Awake()
    {
        _onGameExitEventListener.Add(Exit);
        _playerDataManager = transform.GetComponentInChildren<IDataManager>();
        _playerDataManager.OnInitializationComplete += StartGame;
    }
    private void Start()
    {
        _playerDataManager.Initialize();
    }
    public void StartLevel()
    {
        EventBus<OnLevelStartedEvent>.RaiseEvent(new OnLevelStartedEvent());
    }
    public void RestartLevel()
    {
        EventBus<OnLevelRestartedEvent>.RaiseEvent(new OnLevelRestartedEvent());
    }
    public void EndLevel()
    {
        EventBus<OnLevelExitEvent>.RaiseEvent(new OnLevelExitEvent());
    }
    private void StartGame()
    {
        _playerDataManager.OnInitializationComplete -= StartGame;
        EventBus<OnGameStartedEvent>.RaiseEvent(new OnGameStartedEvent());
    }
    private void Exit()
    {
        Debug.Log("close application");
        Application.Quit();
    }
}
