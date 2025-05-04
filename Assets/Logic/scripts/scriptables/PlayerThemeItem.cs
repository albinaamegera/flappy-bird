using UnityEngine;

[CreateAssetMenu(menuName = "scriptables/player theme item", fileName = "new theme item")]
public class PlayerThemeItem : ShopItem
{
    public PlayerThemes Theme => _theme;
    public LevelPart LevelPart => _levelPart;
    public LevelPart Background => _background;

    [SerializeField] private PlayerThemes _theme;
    [SerializeField] private LevelPart _levelPart;
    [SerializeField] private LevelPart _background;
}
public enum PlayerThemes
{
    Default,
    Evening,
    Night,
    StarNight
}
