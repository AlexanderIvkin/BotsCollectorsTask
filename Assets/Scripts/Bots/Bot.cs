using System;
using System.Collections;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private Base _base;
    [SerializeField] private Transform _cargoPosition;
    [SerializeField] private BotMover _botMover;
    [SerializeField] private BotRotator _botRotator;

    private Resource _transportedCargo;

    public event Action<Bot, Resource> CargoDelivered;

    public IEnumerator BringCargo(Resource resource)
    {
        yield return GoTarget(resource.transform, resource.GetReachedDistane());

        TakeCargo(resource);

        yield return GoTarget(_base.transform, _base.GetReachedDistane());

        RemoveCargo();
    }

    private IEnumerator GoTarget(Transform target, float reachedDistance)
    {
        while (Vector3.Distance(transform.position, target.position) > reachedDistance)
        {
            _botMover.Move(target);
            _botRotator.Rotate(target);

            yield return null;
        }
    }

    private void TakeCargo(Resource resource)
    {
        _transportedCargo = resource;
        resource.transform.SetParent(_cargoPosition.transform);
        resource.transform.localPosition = Vector3.zero;
    }

    private void RemoveCargo()
    {
        CargoDelivered?.Invoke(this, _transportedCargo);
        _transportedCargo.Disable();
    }
}
