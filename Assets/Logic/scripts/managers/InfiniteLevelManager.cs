using System.Linq;
using UnityEngine;

public class InfiniteLevelManager : MonoBehaviour
{
    [Header("settings")]
    [SerializeField] protected LevelPart _levelpart;
    [SerializeField] protected Timer _timer;
    [SerializeField] protected float _startXPos;
    //[SerializeField] private float _levelpartWidth;
    [SerializeField] protected int _partsCount;

    protected LevelPart[] _partsOnLevel;
    protected Camera _camera;
    protected float _cameraHalfWidth;
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
            //var x = _startXPos + i * _levelpartWidth;
            var part = Instantiate(_levelpart, Vector2.zero, Quaternion.identity);
            if (i == 0)
            {
                part.Move(_startXPos);
            }
            else
            {
                part.Move(_partsOnLevel[i - 1].transform.position.x);
            }
            _partsOnLevel[i] = part;
        }
    }
    protected virtual void CheckCameraBorders()
    {
        if (_camera.transform.position.x - _cameraHalfWidth > _partsOnLevel[0].transform.position.x)
        {
            MoveLastToFirst();
        }
    }
    protected void MoveLastToFirst()
    {
        var first = _partsOnLevel[0];
        //first.transform.position = new Vector2(_partsOnLevel[_partsCount - 1].transform.position.x + _levelpartWidth, 0f);
        first.Move(_partsOnLevel[_partsCount - 1].transform.position.x);

        for (int i = 0; i < _partsCount - 1; i++)
        {
            _partsOnLevel[i] = _partsOnLevel[i + 1];
        }

        _partsOnLevel[_partsCount - 1] = first;
    }
}