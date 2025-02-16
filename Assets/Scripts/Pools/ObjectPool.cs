using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T: PoolableObject
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _capacity;

    private Queue<T> _pool = new ();

    private void Awake()
    {
        Fill();
    }

    public T Get(Vector3 position)
    {
        T currentResource;

        if (_pool.Count > 0)
        {
            currentResource = _pool.Dequeue();
        }
        else
        {
            currentResource = Create();
        }

        currentResource.transform.position = position;
        currentResource.gameObject.SetActive(true);

        return currentResource;
    }

    public void Release(T poolableObject)
    {
        _pool.Enqueue(poolableObject);
    }

    private void Fill()
    {
        for ( int i = 0; i < _capacity; i++)
        {
            _pool.Enqueue(Create());
        }
    }

    private T Create()
    {
        return Instantiate(_prefab);
    }
}
