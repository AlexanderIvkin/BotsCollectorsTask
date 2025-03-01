using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput _playerInput;

    public event Action<Vector2> DirectionChanged;
    public event Action Stopped;
    public event Action Clicked;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Camera.Move.performed += OnMove;
        _playerInput.Camera.Move.canceled += ctx => OnStop();
        _playerInput.Mouse.Click.performed += OnClick;
    }

    private void OnDisable()
    {
        _playerInput.Camera.Move.performed -= OnMove;
        _playerInput.Camera.Move.canceled -= ctx => OnStop();
        _playerInput.Mouse.Click.performed -= OnClick;
        _playerInput.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        DirectionChanged?.Invoke(context.action.ReadValue<Vector2>());
    }

    private void OnStop()
    {
        Stopped?.Invoke();
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        Debug.Log("Вызываю клик");
        Clicked?.Invoke();
    }
}
