using UnityEngine;

namespace Cards
{
    internal sealed class YPositionUpdater : IYPositionUpdater
    {
        private IYPositionUpdaterData _data;

        public YPositionUpdater(IYPositionUpdaterData data)
        {
            _data = data;
        }

        public void Update()
        {
            Vector3 YPosition = _data.YPositionTransform.localPosition;
            YPosition.y = -_data.YPosition;
            _data.YPositionTransform.localPosition = YPosition;
        }
    }
}