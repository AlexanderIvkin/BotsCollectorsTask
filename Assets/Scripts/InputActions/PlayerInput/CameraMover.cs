using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private InputReader _inputReader;

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
            transform.Translate(new Vector3(direction.x, 0, direction.y));
        }
    }

    private void Stop()
    {
        Debug.Log("Остановился");
    }
}
