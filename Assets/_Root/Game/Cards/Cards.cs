using System.Collections.Generic;
using UnityEngine;

internal sealed class Cards
{
    private List<Card> _upSideCards = new();
    private List<Card> _list = new();

    public bool IsEmpty()
    {
        return _list.Count == 0;
    }

    private void InstantiateCard(Vector3 position, int value)
    {
        Card card = new(value);
        card.Instantiate(position);
        _list.Add(card);
    }

    public void InstatiateCards()
    {
        CardsGenerator cardsGenerator = new();

        for (int i = 0; i < 16; i++)
        {
            Vector3 position = cardsGenerator.PullPosition();
            int number = cardsGenerator.PullCardNumber();
            InstantiateCard(position, number);
        }
    }

    public void Update(float deltaTime)
    {
        _upSideCards.Clear();
        for (int i = 0; i < _list.Count; i++)
        {
            _list[i].Update(deltaTime);
            if (_list[i].IsUp) _upSideCards.Add(_list[i]);
        }
        UpdateUpSideCards();
    }

    public void DestroyCard(Card card)
    {
        card.Destroy();
        _list.Remove(card);
    }

    private void UpdateUpSideCards()
    {
        while (_upSideCards.Count >= 2)
        {
            Card FirstCard = _upSideCards.Pull();
            Card SecondCard = _upSideCards.Pull();
            if (FirstCard.Value == SecondCard.Value)
            {
                DestroyCard(FirstCard);
                DestroyCard(SecondCard);
            }
            else
            {
                FirstCard.Rotate();
                SecondCard.Rotate();
            }
        }
    }
}
