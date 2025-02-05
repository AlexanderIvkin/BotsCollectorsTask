using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private PoolableObject _prefab;
    [SerializeField] private int _capacity;

    private Queue<PoolableObject> _pool = new ();

    private void Awake()
    {
        Fill();
    }

    public PoolableObject Get(Vector3 position)
    {
        PoolableObject currentResource;

        if (_pool.Count > 0)
        {
            currentResource = _pool.Dequeue();
        }
        else
        {
            currentResource = Instantiate(_prefab);
        }

        currentResource.transform.position = position;
        currentResource.gameObject.SetActive(true);

        return currentResource;
    }

    public void Release(PoolableObject poolableObject)
    {
        _pool.Enqueue(poolableObject);
    }

    private void Fill()
    {
        for ( int i = 0; i < _capacity; i++)
        {
            _pool.Enqueue(Instantiate(_prefab));
        }
    }
}
