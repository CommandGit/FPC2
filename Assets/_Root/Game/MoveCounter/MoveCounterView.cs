using TMPro;
using UnityEngine;

internal sealed class MoveCounterView : MonoBehaviour
{
    public TMP_Text CounterText => _counterText;

    [SerializeField] private TMP_Text _counterText;
}
