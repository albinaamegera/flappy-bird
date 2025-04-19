using Newtonsoft.Json;
using System;
using UnityEngine;

public class Wallet
{
    public Action<int> OnCoinsChanged;

    private int _money;

    private EventListener<OnCoinCollected> _onCoinCollectedEventListener;

    [JsonConstructor]
    public Wallet(int money)
    {
        _money = money;

        InitListeners();
    }
    public int Money => _money;
    private void CollectCoin() => AddCoins(1);
    private void AddCoins(int value)
    {
        if (value < 0)
        {
            Debug.LogError("out of range exeption in add coins func in wallet !!");
            return;
        }
        _money += value;

        OnValueChanged();
    }

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

        _money -= coins;

        OnValueChanged();
    }
    private void OnValueChanged() => OnCoinsChanged?.Invoke(_money);
    private void InitListeners()
    {
        _onCoinCollectedEventListener = new();
        _onCoinCollectedEventListener.Add(CollectCoin);
    }
}
