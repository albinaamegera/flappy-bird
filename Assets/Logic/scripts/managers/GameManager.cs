using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Action<int> OnScoreAdded;
    public Action OnGameOver;
    public Action OnLevelStart;

    [Header("settings")]
    [SerializeField] private Timer _timer;      // на всякий случай пока не используется

    private int _score = 0;

    private void Awake()
    {
        Instance = this;
    }
    public void AddScore()
    {
        _score++;
        OnScoreAdded?.Invoke(_score);
    }
    public void StartLevel()
    {
        _score = 0;
        OnScoreAdded?.Invoke(_score);
        OnLevelStart?.Invoke();
    }
    public void GameOver()
    {
        OnGameOver?.Invoke();
        Debug.Log("message: gamemanager method invoked");
    }
}
