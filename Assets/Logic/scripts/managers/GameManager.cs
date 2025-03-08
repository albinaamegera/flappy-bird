using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Action<int> OnScoreAdded;
    public Action<int> OnCoinCollected;
    public Action OnGameOver;
    public Action OnLevelStart;

    private int _score = 0;
    private int _coins = 0;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        _coins = PlayerManager.Instance.DataCoins;
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
    public void CollectCoin()
    {
        _coins++;
        OnCoinCollected?.Invoke(_coins);
        Debug.Log("coin collected");
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void GameOver()
    {
        OnGameOver?.Invoke();
        PlayerManager.Instance.UpdateData(_coins, _score);
    }
}
