
internal sealed class Game
{
    private InputSystem _inputSystem = new();

    private IGameState _playState;
    private IGameState _pauseState;
    private IGameState _victoryState;

    private IGameState _currentState;

    public void Start()
    {
        _playState = new PlayState(_inputSystem);
        _pauseState = new PauseState(_inputSystem);
        _victoryState = new VictoryState();

        _currentState = _playState;
    }

    public void ChangeState(GameState newState)
    {
        _currentState.Exit();

        switch (newState)
        {
            case GameState.Pause:
                _currentState = _pauseState;
                break;

            case GameState.Play:
                _currentState = _playState;
                break;

            case GameState.Victory:
                _currentState = _victoryState;
                break;
        }

        _currentState.Enter();
    }

    public void Update(float deltaTime)
    {
        _currentState.Update(deltaTime);

        if (_currentState.NextState != GameState.None) ChangeState(_currentState.NextState);
    }

}

