using UnityEngine;

public class GameManager : MonoBehaviour
{
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
}
