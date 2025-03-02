using UnityEngine;

internal sealed class Card
{
    private const float ROTATE_SPEED = 360f;
    private const float UP_ANGLE = 180f;
    private const float DOWN_ANGLE = 0f;

    public bool IsCreated = false;
    private CardView cardView;
    private GameObject _rootGameObject;

    private float _currentZAngle = DOWN_ANGLE;
    private float _targetZAngle = DOWN_ANGLE;

    public bool IsUp = false;

    public int Value;

    public Card(int value)
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

        cardView.ZRotator.localRotation = Quaternion.Euler(0, 0, _currentZAngle);

        Vector3 YPosition = cardView.YPosition.localPosition;
        YPosition.y = newYPosition;
        cardView.YPosition.localPosition = YPosition;
    }

    public void Instantiate(Vector3 position)
    {
        GameObject prefab = Resources.Load<GameObject>("Card");
        _rootGameObject = GameObject.Instantiate(prefab, position, Quaternion.identity);
        cardView = _rootGameObject.GetComponent<CardView>();
        cardView.Card = this;
        cardView.TextField.text = Value.ToString();
        IsCreated = true;
    }

    public void Destroy()
    {
        GameObject.Destroy(_rootGameObject);
        _rootGameObject = null;
        cardView = null;
        IsCreated = false;
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

    private void UpdateStatus()
    {
        UpdateIsUp();
    }
}
