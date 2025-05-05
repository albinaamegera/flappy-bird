using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("settings")]
    [Tooltip("coin prefab")]
    [SerializeField] private GameObject _coinPrefab;

    [Tooltip("max vertical spawn offset")]
    [SerializeField] private float _maxYOffset;

    [Tooltip("max horizontal spawn offset")]
    [SerializeField] private float _maxXOffset;

    [Tooltip("spawn probability")]
    [Range(0, 100)]
    [SerializeField] private float _spawnFactor;

    private CoinController _currentCoin;
    private Transform _transform;
    private void Awake()
    {
        _transform = transform;
    }
    public void Spawn()
    {
        DestroyCoinIfNotNull();

        if (CalculateProbability())
        {
            var obj = Instantiate(_coinPrefab);
            _currentCoin = obj.GetComponent<CoinController>();
            _currentCoin.SetPosition(CalculatePosition());
        }
        else
        {
            Debug.Log("coin not spawn because random");
        }
    }
    public void Clear() => DestroyCoinIfNotNull();
    private bool CalculateProbability() => Random.Range(0, 100) <= _spawnFactor;
    private Vector2 CalculatePosition()
    {
        float x = Random.Range(-_maxXOffset, _maxXOffset);
        float y = Random.Range(-_maxYOffset, _maxYOffset);
        return new Vector2(x, y) + (Vector2)_transform.position;
    }
    private void DestroyCoinIfNotNull()
    {
        if (_currentCoin != null) Destroy(_currentCoin.gameObject);
    }
}
