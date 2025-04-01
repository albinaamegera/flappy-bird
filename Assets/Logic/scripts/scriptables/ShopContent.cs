using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "scriptables/shop content", fileName = "new content")]
public class ShopContent : ScriptableObject
{
    public IEnumerable<ShopItem> Items { get => _items; }

    [SerializeField] private List<ShopItem> _items;

}
