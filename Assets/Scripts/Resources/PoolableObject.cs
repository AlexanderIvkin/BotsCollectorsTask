using System;
using UnityEngine;

public abstract class PoolableObject : MonoBehaviour
{
    public event Action<PoolableObject> Disabled;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Disable()
    {
        Disabled?.Invoke(this);
        transform.SetParent(null);
        gameObject.SetActive(false);
    }
}
