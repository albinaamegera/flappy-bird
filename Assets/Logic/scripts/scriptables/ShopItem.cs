using UnityEngine;

public abstract class ShopItem : ScriptableObject
{
    public Sprite Sprite { get => _sprite; }
    public int Cost { get => _cost; }
    public int ItemId { get => _itemId; }

    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _cost;
    [SerializeField] private int _itemId;
}
