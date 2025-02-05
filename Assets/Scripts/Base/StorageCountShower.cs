using TMPro;
using UnityEngine;

public class StorageCountShower : MonoBehaviour
{
    [SerializeField] private Storage _storage;
    [SerializeField] private TextMeshProUGUI _textField;

    private void Awake()
    {
        _textField.text = _storage.ResourceCount.ToString();
    }

    private void OnEnable()
    {
        _storage.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _storage.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        _textField.text = value.ToString();
    }
}
