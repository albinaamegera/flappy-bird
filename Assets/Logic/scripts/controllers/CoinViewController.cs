using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CoinViewController : MonoBehaviour
{
    [Header("View Components")]
    [SerializeField] private TMP_Text _text;

    [Header("callbacks")]
    [SerializeField] private UnityEvent _onViewUpdate;

    private Wallet _wallet;
    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
        _wallet.OnCoinsChanged += UpdateView;
        UpdateView(_wallet.Money);
    }
    private void UpdateView(int value)
    {
        _text.text = value.ToString();
        _onViewUpdate.Invoke();
    }
}
