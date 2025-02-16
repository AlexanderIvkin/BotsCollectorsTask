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

    public void Remove(int value)
    {
        if (value <= 0)
            return;

        _resourceCount = Mathf.Clamp(_resourceCount - value, 0, _resourceCount);
        ValueChanged?.Invoke(_resourceCount);
    }
}
