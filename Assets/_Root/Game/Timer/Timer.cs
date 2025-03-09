using System;

internal sealed class Timer : ViewController<TimerView>
{
    private const string PREFAB_PATH = "Timer";

    private const string TIMER_FORMAT = @"hh\:mm\:ss"; //@"hh\:mm\:ss\.fff";

    private float _seconds = 0;
    private bool _enable = false;

    public Timer() : base(PREFAB_PATH)
    {

    }

    public override void Instantiate()
    {
        base.Instantiate();
        UpdateView();
    }

    private void UpdateView()
    {
        TimeSpan interval = TimeSpan.FromSeconds(_seconds);
        string intervalString = interval.ToString(TIMER_FORMAT);
        _view.TextField.text = intervalString;
    }

    public void Update(float deltaTime)
    {
        if (!_enable) return;

        _seconds = _seconds + deltaTime;
        UpdateView();
    }

    public void Start()
    {
        _seconds = 0;
        _enable = true;
        UpdateView();
    }

    public void Stop()
    {
        _enable = false;
    }
}
