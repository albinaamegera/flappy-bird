using UnityEngine;

public class GameManager : MonoBehaviour
{
    // event listeners
    private EventListener<OnGameExitEvent> _onGameExitEventListener = new();
    private void Awake()
    {
        _onGameExitEventListener.Add(Exit);
    }
    private void Start()
    {
        EventBus<OnGameStartedEvent>.RaiseEvent(new OnGameStartedEvent());
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
    private void Exit()
    {
        Debug.Log("close application");
        Application.Quit();
    }
}
