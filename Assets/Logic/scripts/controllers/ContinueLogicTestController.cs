using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ContinueLogicTestController : MonoBehaviour
{
    [SerializeField] private Button _adsButton;
    [SerializeField] private Timer _timer;
    [SerializeField] private UnityEvent _onContinue;

    private void OnEnable()
    {
        _adsButton.onClick.AddListener(Continue);
    }
    private void Continue()
    {
        _onContinue.Invoke();
        //_timer.OnTimerComplete.AddListener(OnContinue);
        //_timer.StartTimer();
        OnContinue();
    }
    private void OnContinue()
    {
        EventBus<OnLevelContinueEvent>.RaiseEvent(new OnLevelContinueEvent());
        //_timer.OnTimerComplete.RemoveAllListeners();
    }
    private void OnDisable()
    {
        _adsButton.onClick.RemoveListener(Continue);
    }
}
