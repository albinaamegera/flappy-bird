using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private UnityEvent _onCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Collect();
        }
    }
    void Collect()
    {
        GameManager.Instance.CollectCoin();
        _onCollected.Invoke();
        // some animations
        gameObject.SetActive(false);
    }
}
