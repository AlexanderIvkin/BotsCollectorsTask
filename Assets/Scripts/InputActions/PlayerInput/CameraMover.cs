using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private PlayerInputHandler _playerInputHandler;

    private Vector2 _direction;

    private void OnEnable()
    {
        _playerInputHandler.DirectionChanged += OnDirectionChanged;
        _playerInputHandler.Stopped += OnStopped;
    }

    private void OnDisable()
    {
        _playerInputHandler.DirectionChanged -= OnDirectionChanged;
        _playerInputHandler.Stopped -= OnStopped;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float stopValue = 0.1f;

        if (_direction.sqrMagnitude < stopValue)
            return;

        transform.position = transform.position + new Vector3(_direction.x, 0, _direction.y) * _speed * Time.fixedDeltaTime;
    }

    private void OnDirectionChanged(Vector2 direction)
    {

        _direction = direction;
    }

    private void OnStopped()
    {
        _direction = Vector2.zero;
    }
}
