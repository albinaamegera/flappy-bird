using UnityEngine;

public class LevelPartTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EventBus<OnPointCollected>.RaiseEvent(new OnPointCollected());
        }
    }
}
