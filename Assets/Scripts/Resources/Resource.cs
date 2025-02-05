using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Resource : PoolableObject, ITargetable
{
    [SerializeField] private float _reachedDistance;

    private Rigidbody _rigidbody;

    public float GetReachedDistane() => _reachedDistance;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }
}
