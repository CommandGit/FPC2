namespace Cards
{
    internal sealed class RotateFinishedChecker : IRotateFinishedChecker
    {
        private IRotateFinishedCheckerData _data;

        public RotateFinishedChecker(IRotateFinishedCheckerData data)
        {
            _data = data;
        }

        public void Check()
        {
            _data.SetRotateFinished(_data.CurrentAngleZ == _data.TargetAngleZ);
        }
    }
}
