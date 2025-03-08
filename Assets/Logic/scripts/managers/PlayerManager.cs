using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public int DataCoins { get => _data.coins; private set => _data.coins = value; }
    public bool RecordDetected { get; private set; } = false;

    [Header("settings")]
    [SerializeField] private PlayerSkinChanger _changer;
    [SerializeField] private PlayerData _data;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }
    
    public void ChangeSkin(Sprite sprite) => _changer.UpdateSkin(sprite);

    public void UpdateData(int coins, int score)
    {
        _data.coins = coins;
        RecordDetected = CheckScore(score);
        if (score > _data.maxScore) _data.maxScore = score;
    }
    /// <summary>
    /// </summary>
    /// <param name="amount"></param>
    /// <returns>возвращает true если у игрока больше монет чем во входном параметре</returns>
    public bool CheckCoins(int amount) => _data.coins >= amount;
    /// <summary>
    /// </summary>
    /// <param name="score"></param>
    /// <returns>возвращает true если входной параметр больше чем максимальный у игрока</returns>
    private bool CheckScore(int score) => _data.maxScore < score;
}
