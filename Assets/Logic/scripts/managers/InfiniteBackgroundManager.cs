public class InfiniteBackgroundManager : InfiniteLevelManager
{
    protected override void SetListeners()
    {
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
