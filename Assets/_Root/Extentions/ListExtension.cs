using System.Collections.Generic;
using UnityEngine;

internal static class ListExtension
{
    public static int GetRandomIndex<T>(this List<T> list)
    {
        return Random.Range(0, list.Count);
    }

    public static T GetRandom<T>(this List<T> list)
    {
        return list[list.GetRandomIndex()];
    }

    public static T GetFromIndexAndRemove<T>(this List<T> list, int index)
    {
        T returnValue = list[index];
        list.RemoveAt(index);
        return returnValue;
    }

    public static T GetRandomAndRemove<T>(this List<T> list)
    {
        int index = list.GetRandomIndex();
        return list.GetFromIndexAndRemove(index);
    }

    public static T Pull<T>(this List<T> list)
    {
        return list.GetFromIndexAndRemove(0);
    }
}
