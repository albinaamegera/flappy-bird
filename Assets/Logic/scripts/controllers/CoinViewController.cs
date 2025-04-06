using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CoinViewController : MonoBehaviour
{
    [Header("View Components")]
    [SerializeField] private TMP_Text _text;

    [Header("callbacks")]
    [SerializeField] private UnityEvent _onViewUpdate;

    // listeners
    private EventListener<OnCoinValueChanged> _onCoinValueChangedEventListener = new();
    // todo : on ubdate coins listener to show current value

    private void Awake()
    {
        _onCoinValueChangedEventListener.Add(e => UpdateView(e.value));
    }
    private void UpdateView(int value)
    {
        _text.text = value.ToString();
        _onViewUpdate.Invoke();
    }
}
