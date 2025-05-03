using UnityEngine;

[CreateAssetMenu(menuName ="scriptables/shop skin item", fileName = "new item")]
public class PlayerSkinItem : ShopItem
{
    public PlayerSkins Skin => _skin;

    [SerializeField] private PlayerSkins _skin;
}
public enum PlayerSkins
{
    Default,
    RedBird,
    BlueBird,
    GreenBird,
    WhiteBird,
    PirpleBird,
    BlackBird,
    DiamondBird,
    Robo,
    Fish,
    Cosmo,
    Dragon,
    BatEye,
    Dino,
    Ghost,
    Scull
}
