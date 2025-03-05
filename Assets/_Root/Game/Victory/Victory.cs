using UnityEngine;
using UnityEngine.SceneManagement;

internal sealed class Victory
{
    private bool _isCreated = false;

    public void Instantiate()
    {
        if (_isCreated) return;

        GameObject prefab = Resources.Load<GameObject>("Victory");
        GameObject go = GameObject.Instantiate(prefab);
        VictoryView view = go.GetComponent<VictoryView>();
        view.ButtonMainMenu.onClick.AddListener(ButtonMainMenuPressed);
        _isCreated = true;
    }

    private void ButtonMainMenuPressed()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
