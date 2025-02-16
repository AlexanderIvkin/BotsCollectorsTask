using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private PlayerInput _playerInput;

    public event Action<Vector2> Moved;
    public event Action Stopped;
    public event Action Clicked;

    private void Awake()
    {
        _playerInput = new PlayerInput();

        _playerInput.Camera.Move.performed += OnMove;
        _playerInput.Camera.Move.canceled += OnStop;
        _playerInput.Mouse.Click.performed += OnClick;
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Moved?.Invoke(context.action.ReadValue<Vector2>());
    }

    private void OnStop(InputAction.CallbackContext context)
    {
        Stopped?.Invoke();
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        Clicked?.Invoke();
    }
}
