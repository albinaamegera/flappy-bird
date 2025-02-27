using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [Tooltip("расстояние на котором камера держится от игрока")]
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _playerTransform;                       // трансформ игрока
    Transform _camera;                          // трансформ камеры

    private void Awake()
    {
        _camera = transform;
    }
    private void LateUpdate()
    {
        _camera.position = new Vector3(_playerTransform.position.x, 0f, 0f) + _offset;
    }
}
