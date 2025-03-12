using TMPro;
using UnityEngine;

public class PointViewController : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private int _counter = 0;

    private EventListener<OnPointCollected> _onPointCollectedEventListener = new();
    private EventListener<OnLevelRestartedEvent> _onLevelRestartedEventListener = new();
    private EventListener<OnLevelExitEvent> _onlevelExitEventListener = new();

    private void Awake()
    {
        _onPointCollectedEventListener.Add(UpdateCounter);
        _onLevelRestartedEventListener.Add(ResetCounter);
        _onlevelExitEventListener.Add(ResetCounter);
    }
    private void ResetCounter()
    {
        _counter = 0;
        UpdateView();
    }
    private void UpdateCounter()
    {
        _counter++;
        UpdateView();
    }
    private void UpdateView() => _text.text = _counter.ToString();
}
