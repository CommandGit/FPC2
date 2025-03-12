
internal sealed class VictoryState : IGameState
{
    public GameState NextState => _nextState;

    private GameState _nextState = GameState.None;
    private Victory _victory = new();

    public void Exit()
    {
        
    }

    public void Enter()
    {
        _victory.Instantiate();
    }

    public void Update(float deltaTime)
    {
        _nextState = GameState.None;
    }
}
