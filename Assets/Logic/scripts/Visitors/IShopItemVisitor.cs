public interface IShopItemVisitor
{
    public void Visit(IShopItemVisitable item);
    public void Visit(PlayerSkinItem item);
}
