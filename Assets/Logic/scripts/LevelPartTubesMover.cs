using UnityEngine;

public class LevelPartsTubesMover : MonoBehaviour
{
    [Header("settings")]
    [Tooltip("tubes holder transform")]
    [SerializeField] private Transform _transform;

    [Tooltip("max vertical shift")]
    [SerializeField] private float _maxYShift;


    private void Awake()
    {
        _transform = transform;
    }
    public void Shift()
    {
        float x = _transform.localPosition.x;
        float y = CalculateYShift();
        _transform.position = new Vector2(x, y);
    }
    private float CalculateYShift() => Random.Range(-_maxYShift, _maxYShift);
}
