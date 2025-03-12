
internal sealed class PlayState : IGameState
{
    public GameState NextState => _nextState;
    
    private GameState _nextState = GameState.None;
    private Cards _cards = new();
    private MoveCounter _moveCounter = new();
    private Timer _timer = new();
    private InputSystem _inputSystem;

    public PlayState(InputSystem inputSystem)
    {
        _inputSystem = inputSystem;
        Init();
    }

    private void Init()
    {
        _cards.InstatiateCards();
        _moveCounter.Instantiate();
        _timer.Instantiate();
    }

    public void Exit()
    {
        
    }

    public void Enter()
    {
        
    }

    public void Update(float deltaTime)
    {
        _nextState = GameState.None;

        _timer.Update(deltaTime);
        _cards.Update(deltaTime);
        _inputSystem.Update();

        if (_inputSystem.CardClicked != null)
        {
            if (_inputSystem.CardClicked.IsDown)
            {
                _moveCounter.Add();
            }
            if (_moveCounter.Counter == 1)
            {
                _timer.Start();
            }
            _inputSystem.CardClicked.Rotate();
        }

        if (_cards.IsEmpty())
        {
            _timer.Stop();
            _nextState = GameState.Victory;
        }
        else if (_inputSystem.PauseClicked)
        {
            _nextState = GameState.Pause;
        }
    }
}
