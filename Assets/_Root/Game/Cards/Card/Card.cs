using UnityEngine;

internal sealed class Card : ViewController<CardView>
{
    private const string PREFAB_PATH = "Card";

    private const float ROTATE_SPEED = 360f;
    private const float UP_ANGLE = 180f;
    private const float DOWN_ANGLE = 0f;

    private float _currentZAngle = DOWN_ANGLE;
    private float _targetZAngle = DOWN_ANGLE;

    public bool IsUp = false;
    public bool IsDown = true;

    public int Value;

    public Card(int value) : base(PREFAB_PATH)
    {
        Value = value;
    }

    private void Rotating(float deltaTime)
    {
        if (_currentZAngle == _targetZAngle) return;

        _currentZAngle = Mathf.MoveTowards(_currentZAngle, _targetZAngle, ROTATE_SPEED * deltaTime);
        float newYPosition = Mathf.Sin(Mathf.PI * _currentZAngle / 180f) / 2f;
        UpdateStatus();

        if (!IsCreated) return;

        _view.ZRotator.localRotation = Quaternion.Euler(0, 0, _currentZAngle);

        Vector3 YPosition = _view.YPosition.localPosition;
        YPosition.y = newYPosition;
        _view.YPosition.localPosition = YPosition;
    }

    public void Instantiate(Vector3 position)
    {
        Instantiate(position, Quaternion.identity);
        _view.Card = this;
        _view.TextField.text = Value.ToString();
    }

    public void Update(float deltaTime)
    {
        Rotating(deltaTime);
    }

    public void Rotate()
    {
        if (_targetZAngle == DOWN_ANGLE)
        {
            _targetZAngle = UP_ANGLE;
        }
        else
        {
            _targetZAngle = DOWN_ANGLE;
        }
    }

    private void UpdateIsUp()
    {
        IsUp = (_currentZAngle == _targetZAngle && _targetZAngle == UP_ANGLE);
    }

    private void UpdateIsDown()
    {
        IsDown = (_currentZAngle == _targetZAngle && _targetZAngle == DOWN_ANGLE);
    }

    private void UpdateStatus()
    {
        UpdateIsUp();
        UpdateIsDown();
    }
}
