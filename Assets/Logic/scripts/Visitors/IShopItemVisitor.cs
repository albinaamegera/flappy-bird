public interface IShopItemVisitor
{
    public void Visit(ShopItem item);
    public void Visit(PlayerSkinItem item);
    public void Visit(PlayerThemeItem item);
}
