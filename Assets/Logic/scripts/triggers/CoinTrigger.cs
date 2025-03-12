using UnityEngine;
using UnityEngine.Events;

public class CoinTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent onTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            onTrigger.Invoke();
        }
    }
}
