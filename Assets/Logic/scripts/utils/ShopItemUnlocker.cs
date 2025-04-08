using UnityEngine;

public class ShopItemUnlocker : IShopItemVisitor
{
    private IPersistentData _persistentData;
    public ShopItemUnlocker(IPersistentData persistentData) => _persistentData = persistentData;
    public void Visit(ShopItem item) => Visit((dynamic)item);
    public void Visit(PlayerSkinItem item) => _persistentData.PlayerData.OpenSkin(item);
}
