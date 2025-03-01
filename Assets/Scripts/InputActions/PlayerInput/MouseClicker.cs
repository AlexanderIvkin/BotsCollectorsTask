using UnityEngine;

public class MouseClicker : MonoBehaviour
{
    [SerializeField] private PlayerInputHandler _playerInputHandler;

    private void OnEnable()
    {
        _playerInputHandler.Clicked += Click;
    }

    private void OnDisable()
    {
        _playerInputHandler.Clicked -= Click;
    }

    private void Click()
    {
        Debug.Log("Click");
    }
}
