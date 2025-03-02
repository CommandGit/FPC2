using Extension;
using UnityEngine;

internal sealed class Game
{
    private Cards _cards = new();
    private InputSystem _inputSystem = new();

    public void Start()
    {
        _cards.InstatiateCards();
    }

    public void Update(float deltaTime)
    {
        _cards.Update(deltaTime);
        _inputSystem.Update();

        if (_inputSystem.CardClicked != null)
        {
            _inputSystem.CardClicked.Rotate();
        }

        _cards.UpdateUpSideCards();
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

        if (_cards.IsEmpty())
        {
            Debug.Log("Victory");
        }
    }
}
