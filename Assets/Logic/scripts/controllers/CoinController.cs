using UnityEngine;

public class CoinController : MonoBehaviour
{
    [Header("settings")]
    [SerializeField] private Coin _coin;
    [SerializeField] private float _verticalBorder;
    [SerializeField] private float _xOffset;

    public void LocateCoin(float yCenter)
    {
        _coin.Restart(CalculateRandomPosition(yCenter));
    }
    private Vector2 CalculateRandomPosition(float yCenter)
    {
        var randomY = Random.Range(-_verticalBorder, _verticalBorder);
        return transform.position + new Vector3(_xOffset, randomY + yCenter);
    }
}
