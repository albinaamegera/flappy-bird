using UnityEngine;

public abstract class ShopItem : ScriptableObject
{
    public Sprite Sprite { get => _sprite; }
    public int Cost { get => _cost; }

    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _cost;
}
