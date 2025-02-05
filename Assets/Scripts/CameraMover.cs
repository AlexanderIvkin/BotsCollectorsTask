using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerInput _input;
    private Vector2 _direction;

    private void Awake()
    {
        _input = new PlayerInput();

        _input.Camera.Move.performed += OnMove;
        _input.Camera.Move.canceled += OnStop;
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float stopValue = 0.1f;

        if (_direction.sqrMagnitude < stopValue)
            return;

        float scaledSpeed = _speed * Time.deltaTime;
        Vector3 offset = new Vector3(_direction.x, 0f, _direction.y) * scaledSpeed;

        transform.Translate(offset);
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.action.ReadValue<Vector2>();
    }

    private void OnStop(InputAction.CallbackContext context)
    {
        _direction = Vector2.zero;
    }
}
