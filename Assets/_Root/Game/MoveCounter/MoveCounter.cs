
internal sealed class MoveCounter : ViewController<MoveCounterView>
{
    private const string PREFAB_PATH = "MoveCounter";

    public int Counter => _counter;

    private int _counter = 0;

    public MoveCounter() : base(PREFAB_PATH)
    {

    }

    public override void Instantiate()
    {
        base.Instantiate();
        UpdateView();
    }

    private void UpdateView()
    {
        _view.CounterText.text = _counter.ToString();
    }

    public void Add()
    {
        _counter++;
        UpdateView();
    }

}
