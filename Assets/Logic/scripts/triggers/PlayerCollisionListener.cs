using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionListener : MonoBehaviour
{
    [SerializeField] private UnityEvent _playerCollisionCallback;

    private EventListener<OnPlayerCollision> _onPlayerCollisionEventListener = new();

    private void Awake()
    {
        _onPlayerCollisionEventListener.Add(_playerCollisionCallback.Invoke);
    }
}
