using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public Action<Skin> OnSkinChanged;

    private int _currentID = 0;
    private List<Skin> _skins;

    private void Awake()
    {
        _skins = new();
        System.Object[] objects = Resources.LoadAll("scriptables/skins", typeof(Skin));

        foreach(var obj in objects)
        {
            _skins.Add(obj as Skin);
        }
    }
    private void Start()
    {
        OnSkinChanged?.Invoke(_skins[_currentID]);
    }
    public void ShowNextSkin() => ShowSkin(1);
    public void ShowPrevSkin() => ShowSkin(-1);
    private void ShowSkin(int nextId)
    {
        int newId = _currentID + nextId >= _skins.Count ? _currentID :
            _currentID + nextId < 0 ? 0 : _currentID + nextId;

        _currentID = newId;
        OnSkinChanged?.Invoke(_skins[_currentID]);
    }
}
