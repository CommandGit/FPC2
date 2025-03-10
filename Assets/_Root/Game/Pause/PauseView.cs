using UnityEngine;
using UnityEngine.UI;

internal sealed class PauseView : MonoBehaviour
{
    [SerializeField] private Button _buttonResume;
    [SerializeField] private Button _buttonMainMenu;

    public Button ButtonResume => _buttonResume;
    public Button ButtonMainMenu => _buttonMainMenu;

}
