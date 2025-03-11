
using System.Collections.Generic;
using UnityEngine;

internal sealed class CardsGenerator
{
    private List<Vector3> _listPositions = new();
    private List<int> _listCardNumbers = new();

    public CardsGenerator()
    {
        GeneratePositions(4, 4, 1f, 1.5f);
        GenerateCardNumbers(8);
    }

    public Vector3 PullPosition()
    {
        return _listPositions.GetRandomAndRemove();
    }

    public int PullCardNumber()
    {
        return _listCardNumbers.GetRandomAndRemove();
    }

    public void GeneratePositions(int countX, int countZ, float stepX, float stepZ)
    {
        for (int x = 0; x < countX; x++)
        {
            for (int z = 0; z < countZ; z++)
            {
                float xPosition = (float)x * stepX;
                float zPosition = (float)z * stepZ;
                Vector3 position = new Vector3(xPosition, 0, zPosition);
                _listPositions.Add(position);
            }
        }
    }

    public void GenerateCardNumbers(int pairCount)
    {
        for (int i = 0; i < pairCount; i++)
        {
            _listCardNumbers.Add(i);
            _listCardNumbers.Add(i);
        }
    }
}
