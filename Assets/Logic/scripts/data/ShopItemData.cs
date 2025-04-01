using UnityEngine;

public class ShopItemData
{
    public ShopItem Item { get; private set; }
    public bool IsLocked { get; private set; }
    public bool IsSelected { get; private set; }

    public ShopItemData(ShopItem item, bool isLocked = true, bool isSelected = false)
    {
        Item = item;
        IsLocked = isLocked;
        IsSelected = isSelected;
    }
}
