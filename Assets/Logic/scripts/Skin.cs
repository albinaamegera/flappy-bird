using UnityEngine;
[CreateAssetMenu(menuName = "scriptables/skin", fileName = "new skin")]
public class Skin : ScriptableObject
{
    public Sprite Sprite { get => _sprite; }
    public bool IsLocked { get => _isLocked; }

    [SerializeField] private Sprite _sprite;
    [SerializeField] private bool _isLocked;

    public void Unlock() => _isLocked = false;
}
