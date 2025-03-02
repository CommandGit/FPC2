using TMPro;
using UnityEngine;

internal sealed class CardView : MonoBehaviour
{
    public Transform ZRotator => _zRotator;
    public Transform YPosition => _yPosition;

    public TMP_Text TextField => _textField;

    [SerializeField] private Transform _zRotator;
    [SerializeField] private Transform _yPosition;
    [SerializeField] private TMP_Text _textField;

    public Card Card;

}