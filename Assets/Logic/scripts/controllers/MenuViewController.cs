using UnityEngine;
using UnityEngine.UI;

public class MenuViewController : ViewController
{
    [Header("buttons")]
    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _exitBtn;

    private void Awake()
    {
        _playBtn.onClick.AddListener(OnPlayPressed);
        _exitBtn.onClick.AddListener(OnExitPressed);
    }
    private void OnPlayPressed()
    {
        EventBus<OnLevelStartedEvent>.RaiseEvent(new OnLevelStartedEvent());
    }
    private void OnExitPressed()
    {
        EventBus<OnGameExitEvent>.RaiseEvent(new OnGameExitEvent());
    }
}
