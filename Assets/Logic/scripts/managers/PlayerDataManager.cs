using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    [SerializeField] private PlayerDataConfig _playerConfig;

    private IPersistentData _persistentData;
    private IDataProvider _localProvider;

    private EventListener<OnDataSave> _onDataSaveEventListener = new();

    private void Start()
    {
        _onDataSaveEventListener.Add(SaveData);

        InitializeData();

        SendInitializedData();
    }
    private void InitializeData()
    {
        _persistentData = new PersistentData();
        _localProvider = new DataLocalProvider(_persistentData);

        LoadDataOrInit();
    }
    private void SendInitializedData()
    {
        EventBus<OnDataInitialized>.RaiseEvent(new OnDataInitialized()
        {
            persistentData = _persistentData
        });
    }
    private void LoadDataOrInit()
    {
        if (!_localProvider.TryLoad())
            _persistentData.PlayerData = new PlayerData(_playerConfig);
    }
    private void SaveData()
    {
        _localProvider.Save();
    }
}
