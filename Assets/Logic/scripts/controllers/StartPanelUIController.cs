using UnityEngine;
using UnityEngine.UI;

public class StartPanelUIController : MonoBehaviour
{
    [Header("references")]
    [SerializeField] private SkinManager _manager;
    [SerializeField] private Image _playerSprite;
    [SerializeField] private Image _lockedsprite;
    [Header("buttons")]
    [SerializeField] private Button _leftArrowBtn;
    [SerializeField] private Button _rightArrowBtn;
    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _unlockBtn;

    private void Awake()
    {
        _manager.OnSkinChanged += ChangeSkin;
        _leftArrowBtn.onClick.AddListener(_manager.ShowPrevSkin);
        _rightArrowBtn.onClick.AddListener(_manager.ShowNextSkin);

        // логика для разблокировки персонажа
    }
    private void Start()
    {
        _playBtn.onClick.AddListener(delegate { PlayerManager.Instance.ChangeSkin(_playerSprite.sprite); }); 
    }
    private void ChangeSkin(Skin skin)
    {
        _playerSprite.sprite = skin.Sprite;

        CheckLocked(skin.IsLocked);
    }
    private void CheckLocked(bool isLocked)
    {
        _lockedsprite.enabled = isLocked;
        _playBtn.gameObject.SetActive(!isLocked);
        _unlockBtn.gameObject.SetActive(isLocked);
    }
}
