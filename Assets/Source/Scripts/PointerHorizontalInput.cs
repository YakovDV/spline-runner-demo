using UnityEngine;

public class PointerHorizontalInput : MonoBehaviour, IHorizontalInput
{
    [SerializeField] private float _sensitivity = 1f;

    private float _lastPosition;
    private bool _isDragging;

    public float Delta { get; private set; }

    private void Update()
    {
        Delta = 0f;

        if (Input.GetMouseButtonDown(0))
        {
            _lastPosition = Input.mousePosition.x;
            _isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
            _isDragging = false;

        if (_isDragging == false)
            return;

        float currentPosition = Input.mousePosition.x;
        Delta = (currentPosition - _lastPosition) / Screen.width * _sensitivity;

        _lastPosition = currentPosition;
    }
}