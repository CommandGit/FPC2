using UnityEngine;

namespace Cards
{
    internal sealed class YPositionCalculator : IYPositionCalculator
    {
        private IYPositionCalculatorData _data;

        public YPositionCalculator(IYPositionCalculatorData data)
        {
            _data = data;
        }

        public void Calculate()
        {
            float newYPosition = Mathf.Sin(Mathf.PI * _data.CurrentAngleZ / 180f) / 2f;
            _data.SetYPosition(newYPosition);
        }
    }
}