using UnityEngine;

public class PlayerCollisionTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            EventBus<OnPlayerCollision>.RaiseEvent(new OnPlayerCollision());
        }
    }
}
