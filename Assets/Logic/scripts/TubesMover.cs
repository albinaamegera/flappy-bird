using UnityEngine;

public class TubesMover : MonoBehaviour
{
    [Header("settings")]
    [SerializeField] private Transform _topTube;
    [SerializeField] private Transform _bottomTube;
    [SerializeField] private float _distBetweenCenterAndTube;
    [SerializeField] private float _maxYOffset;

    Transform _transform;
    

    private void Awake()
    {
        _transform = transform;
    }

    public void CalculateTubesPosition()
    {
        float yPos = Random.Range(-_maxYOffset, _maxYOffset);
        _topTube.localPosition = new Vector2(0f, yPos + _distBetweenCenterAndTube);
        _bottomTube.localPosition = new Vector2(0f, yPos - _distBetweenCenterAndTube);
    }
}
