using UnityEngine;
using UnityEngine.Events;

public class LevelPart : MonoBehaviour
{
    [SerializeField] private UnityEvent _moveCallback;
    [SerializeField] private UnityEvent _removeCallback;
    Transform _transform;
    BoxCollider2D _collider;
    float _width;

    protected void Awake()
    {
        _transform = transform;
        _collider = GetComponent<BoxCollider2D>();
        _width = _collider.bounds.size.x;
    }
    public void Move(float xPos)
    {
        _transform.position = new Vector2(xPos + _width, transform.position.y);
        _moveCallback?.Invoke();
    }
    public void Remove()
    {
        _removeCallback?.Invoke();
        Destroy(gameObject);
    }
}
