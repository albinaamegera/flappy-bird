using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class DataLocalProvider : IDataProvider
{
    private const string FileName = "PlayerSave";
    private const string FileSavingExtension = ".json";

    private IPersistentData _persistentData;

    public DataLocalProvider(IPersistentData persistentData) => _persistentData = persistentData;

    private string SavePath => Application.persistentDataPath;
    private string FullPath => Path.Combine(SavePath, $"{FileName}{FileSavingExtension}");
    public bool TryLoad()
    {
        if (!IsDataAlreadyExists())
            return false;

        _persistentData.PlayerData = JsonConvert.DeserializeObject<PlayerData>(File.ReadAllText(FullPath));
        return true;
    }
    public void Save()
    {
        File.WriteAllText(FullPath, JsonConvert.SerializeObject(_persistentData.PlayerData, Formatting.Indented, new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        }));
    }
    public void Delete()
    {

    }
    private bool IsDataAlreadyExists() => File.Exists(FullPath);
}
