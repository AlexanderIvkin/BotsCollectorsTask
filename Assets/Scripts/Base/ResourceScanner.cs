using System.Collections.Generic;
using UnityEngine;

public class ResourceScanner : MonoBehaviour
{
    [SerializeField] private float _maxRadius;
    [SerializeField] private LayerMask _layerMask;

    public List<Resource> GetFoundResources()
    {
        List<Resource> foundedResources = new();
        Collider[] foundedResourcesColliders = Physics.OverlapSphere(transform.position, _maxRadius, _layerMask);

        if (foundedResourcesColliders.Length == 0)
            return null;

        foreach(Collider collider in foundedResourcesColliders)
        {
            if (collider.gameObject.TryGetComponent(out Resource resource))
            {
                foundedResources.Add(resource);
            }
        }

        return foundedResources;
    }
}
