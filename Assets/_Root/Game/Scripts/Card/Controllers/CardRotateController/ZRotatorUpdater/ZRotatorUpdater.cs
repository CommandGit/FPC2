using UnityEngine;

namespace Cards
{
    internal sealed class ZRotatorUpdater : IZRotatorUpdater
    {
        private IZRotatorUpdaterData _data;

        public ZRotatorUpdater(IZRotatorUpdaterData data)
        {
            _data = data;
        }

        public void Update()
        {
            _data.ZRotatorTransform.localRotation = Quaternion.Euler(0, 0, _data.CurrentAngleZ);
        }
    }

}