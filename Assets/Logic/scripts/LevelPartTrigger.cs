using UnityEngine;

public class LevelPartTrigger : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log(" + 1 point");
        }
    }
}
