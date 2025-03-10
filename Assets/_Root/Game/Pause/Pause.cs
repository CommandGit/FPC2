
internal sealed class Pause : ViewController<PauseView>
{
    private const string PREFAB_PATH = "Pause";

    private bool _isButtonResumePressed = false;
    private bool _isButtonMainMenuPressed = false;

    private bool _onUpdateButtonResumePressed = false;
    private bool _onUpdateButtonMainMenuPressed = false;

    public bool ButtonResumePressed => _onUpdateButtonResumePressed;
    public bool ButtonMainMenuPressed => _onUpdateButtonMainMenuPressed;

    public Pause() : base(PREFAB_PATH)
    {

    }

    public override void Instantiate()
    {
        base.Instantiate();
        _view.ButtonResume.onClick.AddListener(OnButtonResumePressed);
        _view.ButtonMainMenu.onClick.AddListener(OnButtonMainMenuPressed);
    }

    private void OnButtonResumePressed()
    {
        _isButtonResumePressed = true;
    }

    private void OnButtonMainMenuPressed()
    {
        _isButtonMainMenuPressed = true;
    }

    public void Update()
    {
        _onUpdateButtonResumePressed = _isButtonResumePressed;
        _onUpdateButtonMainMenuPressed = _isButtonMainMenuPressed;
        _isButtonResumePressed = false;
        _isButtonMainMenuPressed = false;
    }
}
