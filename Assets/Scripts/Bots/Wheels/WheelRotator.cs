using UnityEngine;

public class WheelRotator : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speedRotation;

    private void FixedUpdate()
    {
        transform.Rotate(Time.fixedDeltaTime * _speedRotation * _rigidbody.velocity.magnitude , 0f, 0f);
    }
}
