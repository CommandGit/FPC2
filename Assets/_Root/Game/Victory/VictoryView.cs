using UnityEngine;
using UnityEngine.UI;

internal sealed class VictoryView : MonoBehaviour
{
    public Button ButtonMainMenu => _buttonMainMenu;

    [SerializeField] private Button _buttonMainMenu;
}
