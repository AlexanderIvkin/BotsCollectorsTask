using UnityEngine;

public class BotRotator : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Rotate(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, _speed * Time.deltaTime);
    }
}
