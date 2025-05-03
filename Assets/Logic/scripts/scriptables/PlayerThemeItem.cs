using UnityEngine;

[CreateAssetMenu(menuName = "scriptables/player theme item", fileName = "new theme item")]
public class PlayerThemeItem : ShopItem
{
    public PlayerThemes Theme => _theme;
    public GameObject LevelPart => _levelPart;
    public GameObject Background => _background;

    [SerializeField] private PlayerThemes _theme;
    [SerializeField] private GameObject _levelPart;
    [SerializeField] private GameObject _background;
}
public enum PlayerThemes
{
    Default,
    Evening,
    Night,
    StarNight
}
