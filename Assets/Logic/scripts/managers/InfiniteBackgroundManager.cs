public class InfiniteBackgroundManager : InfiniteLevelManager
{
    // event listeners
    protected EventListener<OnGameStartedEvent> _onGameStartedEventListener = new();
    protected EventListener<OnLevelRestartedEvent> _onLevelRestartedEventListener = new();
    protected EventListener<OnLevelExitEvent> _onLevelExitEventListener = new();

    protected override void SetListeners()
    {
        _onGameStartedEventListener.Add(InstantiateParts);
        _onGameStartedEventListener.Add(SetPartPositions);
        _onLevelRestartedEventListener.Add(SetPartPositions);
        _onLevelExitEventListener.Add(SetPartPositions);
    }
}
