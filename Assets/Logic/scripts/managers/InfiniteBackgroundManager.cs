public class InfiniteBackgroundManager : InfiniteLevelManager
{
    // event listeners
    protected EventListener<OnGameStartedEvent> _onGameStartedEventListener = new();

    protected override void SetListeners()
    {
        _onGameStartedEventListener.Add(InstantiateParts);
        _onGameStartedEventListener.Add(SetPartPositions);
        _onLevelRestartedEventListener.Add(SetPartPositions);
        _onLevelExitEventListener.Add(SetPartPositions);
        _onPlayerThemeChangedEventListener.Add(e => ChangeLevelPart(e.Item.Background));
    }
    protected override void ChangeLevelPart(LevelPart levelPart)
    {
        base.ChangeLevelPart(levelPart);
        ClearParts();
        InstantiateParts();
        SetPartPositions();
    }
}
