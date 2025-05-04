using System;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour, IDataManager
{
    public Action OnInitializationComplete { get; set; }

    [SerializeField] private PlayerDataConfig _playerConfig;

    // components to initialize
    [Header("components to init")]
    [SerializeField] private LevelPanelViewController _levelPanel;
    [SerializeField] private PlayerViewController _playerView;
    [SerializeField] private OptionsViewController _optionsView;
    [SerializeField] private LanguageSwitcher _switcher;

    private IPersistentData _persistentData;
    private IDataProvider _localProvider;

    private EventListener<OnDataSave> _onDataSaveEventListener = new();

    private void Awake()
    {
        _onDataSaveEventListener.Add(SaveData);
    }
    public void Initialize()
    {
        InitializeData();

        InitializeControllers();

        OnInitializationComplete?.Invoke();
    }
    private void InitializeData()
    {
        _persistentData = new PersistentData();
        _localProvider = new DataLocalProvider(_persistentData);

        LoadDataOrInit();
    }
    private void InitializeControllers()
    {
        _levelPanel.Initialize(_persistentData);
        _playerView.InitializeData(_persistentData);
        _optionsView.InitializeData(_persistentData);
        _switcher.InitializeData(_persistentData);
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
