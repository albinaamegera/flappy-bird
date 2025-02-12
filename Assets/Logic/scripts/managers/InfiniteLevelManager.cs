using System.Linq;
using UnityEngine;

public class InfiniteLevelManager : MonoBehaviour
{
    [Header("settings")]
    [SerializeField] private LevelPart _levelpart;
    [SerializeField] private Timer _timer;
    [SerializeField] private float _startXPos;
    [SerializeField] private float _levelpartWidth;
    [SerializeField] private int _partsCount;

    LevelPart[] _partsOnLevel;
    Camera _camera;
    float _cameraHalfWidth;
    private void Awake()
    {
        _camera = Camera.main;
        _cameraHalfWidth = _camera.orthographicSize * _camera.aspect;
    }
    private void Start()
    {
        PrepareLevel();

        _timer.OnTimerComplete.AddListener(CheckCameraBorders);
        _timer.StartTimer();
    }
    private void PrepareLevel()
    {
        _partsOnLevel = new LevelPart[_partsCount];

        for (int i = 0; i < _partsCount; i++)
        {
            var x = _startXPos + i * _levelpartWidth;
            var part = Instantiate(_levelpart, new Vector2(x, 0f), Quaternion.identity);
            _partsOnLevel[i] = part;
        }
    }
    private void CheckCameraBorders()
    {
        if (_camera.transform.position.x - _cameraHalfWidth > _partsOnLevel[0].transform.position.x)
        {
            MoveLastToFirst();
        }
    }
    private void MoveLastToFirst()
    {
        var first = _partsOnLevel[0];
        first.transform.position = new Vector2(_partsOnLevel[_partsCount - 1].transform.position.x + _levelpartWidth, 0f);

        for (int i = 0; i < _partsCount - 1; i++)
        {
            _partsOnLevel[i] = _partsOnLevel[i + 1];
        }

        _partsOnLevel[_partsCount - 1] = first;
    }
}