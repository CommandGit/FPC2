using System.Collections.Generic;
using UnityEngine;

internal sealed class Cards
{
    public List<Card> UpSideCards = new();
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
        InstantiateCard(new Vector3(0f, 0f, 0f), 1);
        InstantiateCard(new Vector3(1f, 0f, 0f), 1);
        InstantiateCard(new Vector3(2f, 0f, 0f), 2);
        InstantiateCard(new Vector3(3f, 0f, 0f), 2);

        InstantiateCard(new Vector3(0, 0, 1.5f), 3);
        InstantiateCard(new Vector3(1, 0, 1.5f), 3);
        InstantiateCard(new Vector3(2, 0, 1.5f), 4);
        InstantiateCard(new Vector3(3, 0, 1.5f), 4);

        InstantiateCard(new Vector3(0f, 0f, 3f), 5);
        InstantiateCard(new Vector3(1f, 0f, 3f), 5);
        InstantiateCard(new Vector3(2f, 0f, 3f), 6);
        InstantiateCard(new Vector3(3f, 0f, 3f), 6);

        InstantiateCard(new Vector3(0, 0, 4.5f), 7);
        InstantiateCard(new Vector3(1, 0, 4.5f), 7);
        InstantiateCard(new Vector3(2, 0, 4.5f), 8);
        InstantiateCard(new Vector3(3, 0, 4.5f), 8);
    }

    public void Update(float deltaTime)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            _list[i].Update(deltaTime);
        }
    }

    public void UpdateUpSideCards()
    {
        UpSideCards.Clear();
        for (int i = 0; i < _list.Count; i++)
        {
            _list[i].UpdateStatus();
            if (_list[i].IsUp) UpSideCards.Add(_list[i]);
        }
    }

    public void DestroyCard(Card card)
    {
        card.Destroy();
        _list.Remove(card);
    }
}
