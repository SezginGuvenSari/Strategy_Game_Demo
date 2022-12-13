using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue<T>
{

    #region References

    private List<Tuple<T, int>> _elements = new List<Tuple<T, int>>();

    #endregion

    #region Properties

    public int Count => _elements.Count;

    #endregion


    public void Enqueue(T item, int priority)
    {
        _elements.Add(Tuple.Create(item, priority));
    }

    public T Dequeue()
    {
        int bestIndex = 0;

        for (int i = 0; i < _elements.Count; i++)
        {
            if (_elements[i].Item2 < _elements[bestIndex].Item2)
            {
                bestIndex = i;
            }
        }

        T bestItem = _elements[bestIndex].Item1;
        _elements.RemoveAt(bestIndex);
        return bestItem;
    }
}
