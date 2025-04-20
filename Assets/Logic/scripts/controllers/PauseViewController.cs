using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PauseViewController : ViewController
{
    [Header("ui references")]
    [SerializeField] private Button _restartBtn;
    [SerializeField] private Button _goToMenuBtn;
    [SerializeField] private TMP_Text _newRecordMes;


    private void Awake()
    {
        _restartBtn.onClick.AddListener(Restart);
        _goToMenuBtn.onClick.AddListener(GoToMenu);
    }
    private void Restart()
    {
        EventBus<OnLevelRestartedEvent>.RaiseEvent(new OnLevelRestartedEvent());
    }
    private void GoToMenu()
    {
        EventBus<OnLevelExitEvent>.RaiseEvent(new OnLevelExitEvent());
    }
    public override void Show()
    {
        base.Show();
    }
    public void Show(bool isRecord)
    {
        if (isRecord)
            _newRecordMes.gameObject.SetActive(true);
        Show();
    }

    public override void Hide()
    {
        _newRecordMes.gameObject.SetActive(false);
        base.Hide();
    }
}
