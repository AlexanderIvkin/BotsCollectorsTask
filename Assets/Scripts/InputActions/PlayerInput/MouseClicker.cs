using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseClicker : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        _inputReader.Clicked += Click;
    }

    private void OnDisable()
    {
        _inputReader.Clicked -= Click;
    }

    private void Click()
    {
        Debug.Log("Click");
    }
}
