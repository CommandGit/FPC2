using UnityEngine.SceneManagement;

internal sealed class MainMenu : ViewController<MainMenuView>
{
    private const string PREFAB_PATH = "MainMenu";

    public MainMenu() : base(PREFAB_PATH)
    {

    }

    public override void Instantiate()
    {
        base.Instantiate();
        _view.ButtonStart.onClick.AddListener(ButtonStartPressed);
    }

    private void ButtonStartPressed()
    {
        SceneManager.LoadScene("GameScene");
    }
}
