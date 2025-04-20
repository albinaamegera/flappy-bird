using UnityEngine;

public class PlayerViewController : ViewController
{
    [SerializeField] private CoinViewController _coinView;
    [Header("shop item panels")]
    [SerializeField] private ShopItemPanelViewController[] _controllers;

    private ShopItemChecker _checker;
    private ShopItemSelector _selector;
    private ShopItemUnlocker _unlocker;

    private IPersistentData _persistentData;
    public void InitializeData(IPersistentData persistentData)
    {
        _persistentData = persistentData;

        InitializeControllers();
    }
    private void InitializeControllers()
    {
        _checker = new(_persistentData);
        _selector = new(_persistentData);
        _unlocker = new(_persistentData);

        foreach (var controller in _controllers)
            controller.Initialize(_checker, _selector, _unlocker, _persistentData.PlayerData.Wallet);

        _coinView.Initialize(_persistentData.PlayerData.Wallet);
    }
}
