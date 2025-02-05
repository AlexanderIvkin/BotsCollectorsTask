using UnityEngine;

public class BotMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;

    public void Move(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        _rigidbody.velocity = direction.normalized * _speed;
    }
}
