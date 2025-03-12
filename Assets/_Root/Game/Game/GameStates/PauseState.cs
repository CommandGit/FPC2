
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

internal sealed class PauseState : IGameState
{
    public GameState NextState => _nextState;

    private GameState _nextState = GameState.None;
    private Pause _pause = new();
    private InputSystem _inputSystem;

    public PauseState(InputSystem inputSystem)
    {
        _inputSystem = inputSystem;
    }

    public void Exit()
    {
        _pause.Destroy();
    }

    public void Enter()
    {
        _pause.Instantiate();
    }

    public void Update(float deltaTime)
    {
        _nextState = GameState.None;

        _inputSystem.Update();
        _pause.Update();
        if (_inputSystem.PauseClicked || _pause.ButtonResumePressed)
        {
            _nextState = GameState.Play;
        }
        else if (_pause.ButtonMainMenuPressed)
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
