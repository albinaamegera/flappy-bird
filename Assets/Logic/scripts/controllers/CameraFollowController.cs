using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [Tooltip("расстояние на котором камера держится от игрока")]
    [SerializeField] private float _xOffset;

    [Tooltip("стартровая позиция камеры")]
    [SerializeField] private Vector3 _startPosition;

    Transform _followTransform;
    Transform _camera;

    private void Awake()
    {
        _camera = transform;
    }
    private void LateUpdate()
    {
        if (_followTransform == null)
        {
            return;
        }
        _camera.transform.position = new Vector3(_followTransform.position.x + _xOffset, 0f, 0f);
    }
    public void SetTarget(Transform target) => _followTransform = target;
    public void ResetPosition() => _camera.position = _startPosition;
}
