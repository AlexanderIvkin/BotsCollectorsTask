using System;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private int _resourceCount = 0;

    public event Action<int> ValueChanged;

    public int ResourceCount => _resourceCount;

    public void Add()
    {
        _resourceCount++;
        ValueChanged?.Invoke(_resourceCount);
    }
}
