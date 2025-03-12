using UnityEngine;
using UnityEngine.Events;

public class CoinController : MonoBehaviour
{
    [SerializeField] private UnityEvent _collectCallback;
    private CircleCollider2D _collider;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _collider = GetComponent<CircleCollider2D>();
    }
    public void SetPosition(Vector2 position) => _transform.position = position;
    public void Collect()
    {
        DisableCollider();
        Debug.Log("coin collected");
        EventBus<OnCoinCollected>.RaiseEvent(new OnCoinCollected());
        SendCallback();
    }
    private void DisableCollider() => _collider.enabled = false;
    private void SendCallback() => _collectCallback.Invoke();
}
