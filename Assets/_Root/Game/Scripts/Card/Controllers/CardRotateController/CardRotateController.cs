namespace Cards
{
    internal sealed class CardRotateController : ICardRotateController
    {
        private ICardRotateControllerData _data;

        private IAngleZCalculator _angleZCalculator;
        private IRotateFinishedChecker _rotateFinishedChecker;
        private IYPositionCalculator _yPositionCalculator;
        private IYPositionUpdater _yPositionUpdater;
        private IZRotatorUpdater _zRotatorUpdater;

        public CardRotateController(ICardRotateControllerData data)
        {
            _data = data;

            _angleZCalculator = new AngleZCalculator(data);
            _rotateFinishedChecker = new RotateFinishedChecker(data);
            _yPositionCalculator = new YPositionCalculator(data);
            _yPositionUpdater = new YPositionUpdater(data);
            _zRotatorUpdater = new ZRotatorUpdater(data);
        }

        public void Update(float deltaTime)
        {
            _rotateFinishedChecker.Check();
            if (_data.RotateFinished) return;

            _angleZCalculator.Calculate(deltaTime);
            _yPositionCalculator.Calculate();
            _yPositionUpdater.Update();
            _zRotatorUpdater.Update();
        }
    }
}