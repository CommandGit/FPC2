using UnityEngine;

namespace Cards
{
    internal sealed class CardView : MonoBehaviour, ICardView
    {
        public Transform ZRotatorTransform => _zRotatorTransform;

        public Transform YPositionTransform => _yPositionTransform;

        [SerializeField] private Transform _zRotatorTransform;
        [SerializeField] private Transform _yPositionTransform;
    }
}