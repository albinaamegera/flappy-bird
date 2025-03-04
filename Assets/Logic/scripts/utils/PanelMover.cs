using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using System;

public class PanelMover : MonoBehaviour
{
    [Header("panels")]
    [SerializeField] private RectTransform[] _panels;
    [Header("next buttons")]
    [SerializeField] private Button[] _nextBtns;
    [Header("prev buttons")]
    [SerializeField] private Button[] _prevBtns;
    [Header("settings")]
    [SerializeField] private float _animDuration = 0.5f;

    private float[] _xPositions;
    private int _currentPanelId = 0;
    private float _screenWidth;
    private void Start()
    {
        _screenWidth = Screen.width;

        CalculatePositions();

        foreach (var btn in _nextBtns)
        {
            btn.onClick.AddListener(ShowNextPanel);
        }
        foreach (var btn in _prevBtns)
        {
            btn.onClick.AddListener(ShowPrevPanel);
        }
    }
    private void ShowNextPanel()
    {
        if (_currentPanelId + 1 > _panels.Length - 1) return;

        _currentPanelId++;

        for (int i = 0; i <= _panels.Length - 1; i++)
        {
            MovePanels(i);    
        }
    }
    private void ShowPrevPanel()
    {
        if (_currentPanelId - 1 < 0) return;

        _currentPanelId--;
        
        for (int i = _panels.Length - 1; i >= 0; i--)
        {
            MovePanels(i);
        }
    }
    private void CalculatePositions()
    {
        _xPositions = new float[_panels.Length];
        for (int i = 0; i < _xPositions.Length; i++)
        {
            _xPositions[i] = i * _screenWidth;
            //_panels[i].position = new Vector3(_xPositions[i])
        }
    }
    private void MovePanels(int index)
    {
        float targetXPos;
        if (index < _currentPanelId)
        {
            targetXPos = 0 - (_currentPanelId - index) * _screenWidth;
        }
        else if (index == _currentPanelId)
        {
            targetXPos = 0;
        }
        else
        {
            targetXPos = 0 + (index - _currentPanelId) * _screenWidth;
        }
        targetXPos += _screenWidth / 2;
        _panels[index].DOMoveX(targetXPos, _animDuration);
    }
}
