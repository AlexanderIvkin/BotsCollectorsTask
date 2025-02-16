using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Rigidbody _rigidbody;

    private void OnEnable()
    {
        _inputReader.Moved += Move;
        _inputReader.Stopped += Stop;
    }

    private void OnDisable()
    {
        _inputReader.Moved -= Move;
        _inputReader.Stopped -= Stop;
    }

    private void Move(Vector2 direction)
    {
        float stopValue = 0.1f;

        if(direction.sqrMagnitude > stopValue)
        {
            _rigidbody.velocity = new Vector3(direction.x, 0, direction.y)* _speed * Time.deltaTime;
        }
    }

    private void Stop()
    {
        Debug.Log("Остановился");
    }
}
