
using UnityEngine;
using UnityEngine.SceneManagement;

internal sealed class MainMenu
{
    public void Show()
    {
        GameObject prefab = Resources.Load<GameObject>("MainManu");
        GameObject go = GameObject.Instantiate(prefab);
        MainMenuView view = go.GetComponent<MainMenuView>();
        view.ButtonStart.onClick.AddListener(ButtonStartPressed);
    }

    private void ButtonStartPressed()
    {
        SceneManager.LoadScene("GameScene");
    }
}
