using UnityEngine;

public class PlayerViewController : ViewController
{
    [SerializeField] private CoinViewController _coinView;
    [Header("shop item panels")]
    [SerializeField] private ShopItemPanelViewController[] _controllers;

    private ShopItemChecker _checker;
    private ShopItemSelector _selector;
    private ShopItemUnlocker _unlocker;

    // event listeners
    private EventListener<OnDataInitialized> _onDataInitializedEventListener = new();

    private void Awake()
    {
        _onDataInitializedEventListener.Add(e => InitializeControllers(
            e.persistentData
        ));
    }
    private void InitializeControllers(IPersistentData persistentData)
    {
        _checker = new(persistentData);
        _selector = new(persistentData);
        _unlocker = new(persistentData);

        foreach (var controller in _controllers)
            controller.Initialize(_checker, _selector, _unlocker, persistentData.PlayerData.Wallet);

        _coinView.Initialize(persistentData.PlayerData.Wallet);
    }
}
