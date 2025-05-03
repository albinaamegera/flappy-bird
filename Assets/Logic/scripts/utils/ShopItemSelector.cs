public class ShopItemSelector : IShopItemVisitor
{
    private IPersistentData _persistentData;
    public ShopItemSelector(IPersistentData persistentData) => _persistentData = persistentData;

    public void Visit(ShopItem item) => Visit((dynamic)item);

    public void Visit(PlayerSkinItem item)
    {
        _persistentData.PlayerData.SelectSkin(item.Skin);
        EventBus<OnPlayerSkinChanged>.RaiseEvent(new OnPlayerSkinChanged() { Sprite = item.Sprite });
    }
    public void Visit(PlayerThemeItem item)
    {
        _persistentData.PlayerData.SelectTheme(item.Theme);
        // invoke event
    }
}
