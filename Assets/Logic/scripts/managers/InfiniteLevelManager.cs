using UnityEngine;

public class InfiniteLevelManager : MonoBehaviour
{
    [Header("settings")]
    [SerializeField] protected Timer _timer;
    [SerializeField] protected float _startXPos;
    [SerializeField] protected float _cameraXBorderOffset;
    [SerializeField] protected int _partsCount;

    protected LevelPart _levelpart;
    protected LevelPart[] _partsOnLevel;
    protected Camera _camera;
    protected float _cameraHalfWidth;

    // listeners
    protected EventListener<OnLevelStartedEvent> _onLevelStartEventListener = new();
    protected EventListener<OnLevelRestartedEvent> _onLevelRestartedEventListener = new();
    protected EventListener<OnLevelExitEvent> _onLevelExitEventListener = new();
    protected EventListener<OnPlayerThemeChanged> _onPlayerThemeChangedEventListener = new();
    private void Awake()
    {
        _camera = Camera.main;
        _cameraHalfWidth = _camera.orthographicSize * _camera.aspect;
        SetListeners();
    }
    private void Start()
    {
        _timer.OnTimerComplete.AddListener(CheckCameraBorders);
    }
    protected virtual void SetListeners()
    {
        _onLevelStartEventListener.Add(InstantiateParts);
        _onLevelStartEventListener.Add(SetPartPositions);
        _onLevelRestartedEventListener.Add(SetPartPositions);
        _onLevelExitEventListener.Add(ClearParts);
        _onPlayerThemeChangedEventListener.Add(e => ChangeLevelPart(e.Item.LevelPart));
    }
    protected virtual void ChangeLevelPart(LevelPart levelPart)
    {
        Debug.Log($"theme was changed : {levelPart.gameObject.name}");
        _levelpart = levelPart;
    }
    protected void InstantiateParts()
    {
        _partsOnLevel = new LevelPart[_partsCount];

        for (int i = 0; i < _partsCount; i++)
        {
            _partsOnLevel[i] = Instantiate(_levelpart, Vector2.zero, Quaternion.identity);
        }
    }
    protected void SetPartPositions()
    {
        _timer.ResetTimer();

        for (int i = 0; i < _partsCount; i++)
        {
            if (i == 0)
            {
                _partsOnLevel[i].Move(_startXPos);
            }
            else
            {
                _partsOnLevel[i].Move(_partsOnLevel[i - 1].transform.position.x);
            }
        }

        _timer.StartTimer();
    }
    protected void ClearParts()
    {
        if (_partsOnLevel == null)
        {
            Debug.LogWarning("no parts on level to clear");
            return;
        }
        for (int i = _partsCount - 1; i >= 0; i--)
        {
            _partsOnLevel[i].Remove();
        }
        _timer.StopTimer();
    }
    protected void CheckCameraBorders()
    {
        if (_camera.transform.position.x - _cameraHalfWidth > _partsOnLevel[0].transform.position.x + _cameraXBorderOffset)
        {
            MoveLastToFirst();
        }
    }
    protected void MoveLastToFirst()
    {
        var first = _partsOnLevel[0];
        first.Move(_partsOnLevel[_partsCount - 1].transform.position.x);

        for (int i = 0; i < _partsCount - 1; i++)
        {
            _partsOnLevel[i] = _partsOnLevel[i + 1];
        }

        _partsOnLevel[_partsCount - 1] = first;
    }
}