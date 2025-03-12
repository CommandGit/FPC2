
internal interface IGameState
{
    public GameState NextState { get; }
    public void Enter();
    public void Update(float deltaTime);
    public void Exit();
}
