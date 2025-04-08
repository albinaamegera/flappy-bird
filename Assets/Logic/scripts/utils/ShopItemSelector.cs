public class ShopItemSelector : IShopItemVisitor
{
    private IPersistentData _persistentData;
    public ShopItemSelector(IPersistentData persistentData) => _persistentData = persistentData;

    public void Visit(IShopItemVisitable item) => item.Accept(this);

    public void Visit(PlayerSkinItem item) => _persistentData.PlayerData.SelectSkin(item);
}
