public class ShopItemChecker : IShopItemVisitor
{
    private IPersistentData _persistentData;
    public bool IsOpened { get; private set; }
    public ShopItemChecker(IPersistentData persistentData) => _persistentData = persistentData;
    public void Visit(IShopItemVisitable item) => item.Accept(this);
    public void Visit(PlayerSkinItem item) => IsOpened = _persistentData.PlayerData.IsSkinOpened(item);
}
