using UnityEngine.SceneManagement;

internal sealed class Victory : ViewController<VictoryView>
{
    private const string PRAFAB_PATH = "Victory";

    public Victory() : base(PRAFAB_PATH)
    {

    }
    public override void Instantiate()
    {
        base.Instantiate();
        _view.ButtonMainMenu.onClick.AddListener(ButtonMainMenuPressed);
    }

    private void ButtonMainMenuPressed()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
