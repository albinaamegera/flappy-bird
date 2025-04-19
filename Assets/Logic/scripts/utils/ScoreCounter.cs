using Newtonsoft.Json;
using System;

public class ScoreCounter 
{
    public Action<int> OnScoreChanged;

    private DateTime _recordDate;
    private int _record;
    private int _currentScore;

    private EventListener<OnPointCollected> _onPointCollectedEventListener;
    private EventListener<OnLevelStartedEvent> _onLevelStartedEventListener;
    private EventListener<OnLevelRestartedEvent> _onLevelRestartedEventListener;

    [JsonConstructor]
    public ScoreCounter(DateTime date, int record)
    {
        _recordDate = date;
        _record = record;
        _currentScore = 0;

        InitListeners();
    }
    public DateTime RecordDate
    {
        get => _recordDate;
        private set
        {
            _recordDate = value;
        }
    }
    public int Record
    {
        get => _record;
        private set
        {
            _record = value;
            RecordDate = DateTime.Now;
        }
    }
    public int CurrentScore
    {
        get => _currentScore;
        private set
        {
            _currentScore = value;
            OnScoreChanged?.Invoke(_currentScore);
        }
    }

    public bool IsRecord() => _currentScore > _record;

    private void ResetScoreWhenLevelRestart()
    {
        if (IsRecord())
        {
            _record = _currentScore;
        }
        CurrentScore = 0;
    }
    private void AddScore() => CurrentScore += 1;
    private void InitListeners()
    {
        _onPointCollectedEventListener = new();
        _onLevelStartedEventListener = new();
        _onLevelRestartedEventListener = new();
        _onPointCollectedEventListener.Add(AddScore);
        _onLevelStartedEventListener.Add(ResetScoreWhenLevelRestart);
        _onLevelRestartedEventListener.Add(ResetScoreWhenLevelRestart);
    }
}
