using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("скорость движения персонажа")]
    [SerializeField] private float _speed;
    Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }
    private void Update()
    {
        _transform.position += Vector3.right * Time.deltaTime * _speed;
    }
}
