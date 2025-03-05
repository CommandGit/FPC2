using UnityEngine;
using UnityEngine.UI;

internal sealed class MainMenuView : MonoBehaviour
{
    public Button ButtonStart => _buttonStart;

    [SerializeField] private Button _buttonStart;
}
