public class ShopItemChecker : IShopItemVisitor
{
    private IPersistentData _persistentData;
    public bool IsOpened { get; private set; }
    public bool IsSelected { get; private set; }
    public ShopItemChecker(IPersistentData persistentData) => _persistentData = persistentData;
    public void Visit(ShopItem item) => Visit((dynamic)item);
    public void Visit(PlayerSkinItem item)
    {
        IsOpened = _persistentData.PlayerData.IsSkinOpened(item.Skin);
        if (!IsOpened)
        {
            IsSelected = false;
            return;
        }
        IsSelected = _persistentData.PlayerData.IsSkinSelected(item.Skin);
    }
    public void Visit(PlayerThemeItem item)
    {
        IsOpened = _persistentData.PlayerData.IsThemeOpened(item.Theme);
        if (!IsOpened)
        {
            IsSelected = false;
            return;
        }
        IsSelected = _persistentData.PlayerData.IsThemeSelected(item.Theme);
    }
}
