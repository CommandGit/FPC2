using UnityEngine;

namespace Cards
{
    internal sealed class AngleZCalculator : IAngleZCalculator
    {
        private IAngleZCalculatorData _data;

        public AngleZCalculator(IAngleZCalculatorData data)
        {
            _data = data;
        }

        public void Calculate(float deltaTime)
        {
            float newAngle = Mathf.MoveTowards(_data.CurrentAngleZ, _data.TargetAngleZ, _data.SpeedAngleZ * deltaTime);
            _data.SetCurrentAngleZ(newAngle);
        }
    }
}
