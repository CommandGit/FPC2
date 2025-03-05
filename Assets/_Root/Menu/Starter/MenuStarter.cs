using UnityEngine;

public class MenuStarter : MonoBehaviour
{
    private Menu _menu;

    private void Start()
    {
        _menu = new();
        _menu.Start();
    }
}
