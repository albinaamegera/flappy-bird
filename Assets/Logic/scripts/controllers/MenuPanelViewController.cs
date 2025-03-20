using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuPanelViewController : PanelViewController
{
    [SerializeField] private ViewController[] _controllers;

    int _currentControllerId = 0;

    // event listeners
    private EventListener<OnTubButtonPressed> _onTabButtonPressedEventListener = new();

    private void Awake()
    {
        _onTabButtonPressedEventListener.Add(e => SwitchController(e.id));
    }
    private void Start()
    {
        ResetControllers();
    }
    private void OnValidate()
    {
        List<ViewController> duplicates = _controllers
            .GroupBy(_controllers => _controllers)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key)
            .ToList();
        foreach(var duplicate in duplicates)
        {
            Debug.LogError(duplicate.ToString());
        }
    }
    public override void Show()
    {
        _controllers[_currentControllerId].Show();
        base.Show();
    }
    public override void Hide()
    {
        ResetControllers();
        base.Hide();
    }
    private void SwitchController(int nextId)
    {
        if (nextId >= _controllers.Length)
        {
            Debug.LogWarning($"no controller of id. check if index is out of bounds. id parametr : {nextId}");
            return;
        }
        _controllers[_currentControllerId].Hide();
        _controllers[nextId].Show();
        _currentControllerId = nextId;
    }
    private void ResetControllers()
    {
        _currentControllerId = 0;
        foreach (var controller in _controllers)
            controller.Hide();
    } 
}
