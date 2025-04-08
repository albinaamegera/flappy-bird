using UnityEngine;

public class Wallet
{
    private IPersistentData _persistentData;
    private int _money;

    private EventListener<OnCoinCollected> _onCoinCollectedEventListener;

    public Wallet(IPersistentData persistentData)
    {
        _persistentData = persistentData;
        _money = _persistentData.PlayerData.Money;
        _onCoinCollectedEventListener = new();
        _onCoinCollectedEventListener.Add(CollectCoin);

        OnValueChanged();
    }
    private void CollectCoin() => AddCoins(1);
    public void AddCoins(int value)
    {
        if (value < 0)
        {
            Debug.LogError("out of range exeption in add coins func in wallet !!");
            return;
        }
        _persistentData.PlayerData.Money += value;
        _money = _persistentData.PlayerData.Money;

        OnValueChanged();
    }
    public int GetCurrentCoins() => _money;

    public bool IsEnough(int coins)
    {
        if (coins < 0)
        {
            Debug.LogError("out of range ex in is enough func in wallet !!");
            return false;
        }
        return _money >= coins;
    }
    public void Spend(int coins)
    {
        if (coins < 0)
        {
            Debug.LogError("out of range ex in spend func in wallet !!");
            return;
        }

        _persistentData.PlayerData.Money -= coins;
        _money = _persistentData.PlayerData.Money;

        OnValueChanged();
    }
    private void OnValueChanged() => EventBus<OnCoinValueChanged>.RaiseEvent(new OnCoinValueChanged() { value = _money });
}
