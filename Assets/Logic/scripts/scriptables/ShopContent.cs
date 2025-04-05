using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "scriptables/shop content", fileName = "new content")]
public class ShopContent : ScriptableObject
{
    public IEnumerable<ShopItem> Items => _items;

    [SerializeField] private List<ShopItem> _items;

    private void OnValidate()
    {
        if (_items.Count == 0)
        {
            Debug.LogError($"{this.name} items list is empty");
            return;
        }
    }
}
