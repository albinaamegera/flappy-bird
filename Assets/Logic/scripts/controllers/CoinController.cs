using UnityEngine;

public class CoinController : MonoBehaviour
{
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }
    public void SetPosition(Vector2 position) => _transform.position = position;
    public void Collect()
    {
        Debug.Log("coin collected");
        EventBus<OnCoinCollected>.RaiseEvent(new OnCoinCollected());
        // movement logic
    }
}
