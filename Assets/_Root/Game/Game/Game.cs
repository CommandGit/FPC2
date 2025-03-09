using Extension;

internal sealed class Game
{
    private Cards _cards = new();
    private InputSystem _inputSystem = new();
    private Victory _victory = new();
    private Timer _timer = new();
    private GameState _state = GameState.None;
    private MoveCounter _moveCounter = new();

    public void Start()
    {
        StartPlaying();
    }

    private void StartPlaying()
    {
        _cards.InstatiateCards();
        _timer.Instantiate();
        //_timer.Start();
        _moveCounter.Instantiate();
        _state = GameState.Playing;
    }

    private void StartVictory()
    {
        _timer.Stop();
        _victory.Instantiate();
        _state = GameState.Victory;
    }

    private void Playing(float deltaTime)
    {
        _timer.Update(deltaTime);
        _cards.Update(deltaTime);

        while (_cards.UpSideCards.Count >= 2)
        {
            Card FirstCard = _cards.UpSideCards.Pull();
            Card SecondCard = _cards.UpSideCards.Pull();
            if (FirstCard.Value == SecondCard.Value)
            {
                _cards.DestroyCard(FirstCard);
                _cards.DestroyCard(SecondCard);
            }
            else
            {
                FirstCard.Rotate();
                SecondCard.Rotate();
            }
        }

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
            StartVictory();
        }
    }
    public void Update(float deltaTime)
    {
        if (_state == GameState.Playing) Playing(deltaTime);
    }

}

