using UnityEngine;

[CreateAssetMenu(menuName ="scriptables/shop item", fileName = "new item")]
public class PlayerSkinItem : ShopItem, IShopItemVisitable
{
    public void Accept(IShopItemVisitor visitor)
    {
        visitor.Visit(this);
        Debug.Log($"{visitor} visits {this.name}");
    }
}
