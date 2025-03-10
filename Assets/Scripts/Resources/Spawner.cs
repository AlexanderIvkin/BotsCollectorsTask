using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _boundX;
    [SerializeField] private float _boundZ;
    [SerializeField] private ResourcesPool _resourcesPool;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;

            PoolableObject poolableObject = _resourcesPool.Get(GeneratePosition());

            poolableObject.Disabled += OnObjectDisable;
        }
    }

    private void OnObjectDisable(PoolableObject poolableObject)
    {
        poolableObject.Disabled -= OnObjectDisable;
        _resourcesPool.Release((Resource)poolableObject);
    }

    private Vector3 GeneratePosition()
    {
        float height = 0.2f;

        return new Vector3(Random.Range(-_boundX, _boundX), height, Random.Range(-_boundZ, _boundZ));
    }
}
