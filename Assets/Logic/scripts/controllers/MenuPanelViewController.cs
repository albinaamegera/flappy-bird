using UnityEngine;

public class MenuPanelViewController : PanelViewController
{
    [SerializeField] private ViewController _menu;

    public override void Show()
    {
        _menu.Show();
        base.Show();
    }
    public override void Hide()
    {
        _menu.Hide();
        base.Hide();
    }
}
