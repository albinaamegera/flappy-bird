using UnityEngine;

public class TabController : MonoBehaviour
{
    public void SendTabId(int id)
    {
        EventBus<OnTubButtonPressed>.RaiseEvent(new OnTubButtonPressed() { id = id });
    }
}
