using UnityEngine;
using UnityEngine.UI;

public class SoundUIController : MonoBehaviour
{
    [Header("UI references")]
    [SerializeField] private Button _prevBtn;
    [SerializeField] private Button _nextBtn;
    [SerializeField] private Image _loadingLine;
    [Header("settings")]
    [Tooltip("change sound step")]
    [Range(.01f, .1f)]
    [SerializeField] private float _step = .1f;
    [Tooltip("если флаг то изменение громкости музыки если нет то звуков")]
    [SerializeField] private bool _flag;

    private void Awake()
    {
        _prevBtn.onClick.AddListener(delegate { ChangeValue(-1); });
        _nextBtn.onClick.AddListener(delegate { ChangeValue(1); });
    }
    public void ChangeValue(int value)
    {
        _loadingLine.fillAmount += value * _step;

        if (_flag)
        {
            SoundManager.Instance.ChangeMusicVolume(_loadingLine.fillAmount);
        } 
        else
        {
            SoundManager.Instance.ChangeSoundVolume(_loadingLine.fillAmount);
        }
    }
}
