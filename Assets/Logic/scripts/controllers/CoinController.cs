using UnityEngine;

public class CoinController : MonoBehaviour
{
    [Header("settings")]
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private float _verticalBorder;
    [SerializeField] private float _xOffset;

    private Coin _currentCoin;

    private void Awake()
    {
        _currentCoin = Instantiate(_coinPrefab);
    }
    public void LocateCoin(float yCenter)
    {
        _currentCoin.transform.position = CalculateRandomPosition(yCenter);
        _currentCoin.gameObject.SetActive(true);
    }
    private Vector2 CalculateRandomPosition(float yCenter)
    {
        var randomY = Random.Range(-_verticalBorder, _verticalBorder);
        return transform.position + new Vector3(_xOffset, randomY + yCenter);
    }
}
