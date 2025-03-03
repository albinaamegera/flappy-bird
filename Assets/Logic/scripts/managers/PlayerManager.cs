using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    [Header("settings")]
    [SerializeField] private PlayerSkinChanger _changer;
    private void Awake()
    {
        Instance = this;
    }
    public void ChangeSkin(Sprite sprite) => _changer.UpdateSkin(sprite);
}
