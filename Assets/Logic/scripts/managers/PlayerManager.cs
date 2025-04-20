using UnityEditor;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("settings")]
    [SerializeField] private GameObject _playerPrefab;

    private PlayerController _player;
    private Sprite _currentSprite;

    // eventlisteners
    private EventListener<OnLevelStartedEvent> _onLevelStartedEventListener = new();
    private EventListener<OnLevelRestartedEvent> _onLevelRestartedEventListener = new();
    private EventListener<OnLevelExitEvent> _onLevelExitEventListener = new();
    private EventListener<OnPlayerCollision> _onPlayerCollisionEventListener = new();
    private EventListener<OnPlayerSkinChanged> _onPlayerSkinChangedEventListener = new();

    private void Awake()
    {
        _onLevelStartedEventListener.Add(InstantiatePlayer);
        _onLevelRestartedEventListener.Add(ResetPlayer);
        _onLevelExitEventListener.Add(RemovePlayer);
        _onPlayerCollisionEventListener.Add(DisablePlayer);
        _onPlayerSkinChangedEventListener.Add(e => _currentSprite = e.Sprite);
    }
    private void InstantiatePlayer()
    {
        var obg = Instantiate(_playerPrefab);
        _player = obg.GetComponent<PlayerController>();
        _player.Setup(_currentSprite);
    }
    private void ResetPlayer() => _player.Restart();
    private void DisablePlayer() => _player.Disable();
    private void RemovePlayer() => _player.Remove();
}
