using TMPro;
using UnityEngine;

internal sealed class TimerView : MonoBehaviour
{
    public TMP_Text TextField => _textfield;

    [SerializeField] private TMP_Text _textfield;
}
