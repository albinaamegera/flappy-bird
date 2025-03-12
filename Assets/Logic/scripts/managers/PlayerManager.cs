using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("settings")]
    [SerializeField] private GameObject _playerPrefab;

    private PlayerController _player;

    // eventlisteners
    private EventListener<OnLevelStartedEvent> _onLevelStartedEventListener = new();
    private EventListener<OnLevelRestartedEvent> _onLevelRestartedEventListener = new();
    private EventListener<OnLevelExitEvent> _onLevelExitEventListener = new();

    private void Start()
    {
        _onLevelStartedEventListener.Add(InstantiatePlayer);
        _onLevelRestartedEventListener.Add(ResetPlayer);
        _onLevelExitEventListener.Add(RemovePlayer);
    }
    private void InstantiatePlayer()
    {
        var obg = Instantiate(_playerPrefab);
        _player = obg.GetComponent<PlayerController>();
        _player.Setup();
    }
    private void ResetPlayer() => _player.Restart();
    private void RemovePlayer() => _player.Remove();
}
