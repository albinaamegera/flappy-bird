using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [Tooltip("расстояние на котором камера держится от игрока")]
    [SerializeField] private Vector3 _offset;
    Transform _transform;                       // трансформ игрока
    Transform _camera;                          // трансформ камеры

    private void Awake()
    {
        _transform = transform;
        _camera = Camera.main.transform;
    }
    private void LateUpdate()
    {
        _camera.transform.position = new Vector3(_transform.position.x, 0f, 0f) + _offset;
    }
}
