using System;
using UnityEngine;

public class TabController : MonoBehaviour
{
    public Action<int> OnTabChanged;
    public void SendTabId(int id) => OnTabChanged?.Invoke(id);
}
