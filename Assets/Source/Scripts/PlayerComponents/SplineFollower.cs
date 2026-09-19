using SplineMesh;
using UnityEngine;

public class SplineFollower : MonoBehaviour
{
    [SerializeField] private PointerHorizontalInput _input;
    [SerializeField] private Spline _spline;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxOffset = 1f;

    private float _distance;
    private float _lateralOffset;

    private void Start()
    {
        Disable();
        Place();
    }

    private void Update()
    {
        _lateralOffset += _input.Delta;
        _lateralOffset = Mathf.Clamp(_lateralOffset, -_maxOffset, _maxOffset);
    }

    private void FixedUpdate()
    {
        _distance += _speed * Time.fixedDeltaTime;
        _distance = Mathf.Min(_distance, _spline.Length);

        Place();

        if (_distance >= _spline.Length)
            Disable();
    }

    public void Initialize(PointerHorizontalInput horizontalInput,Spline spline)
    {
        _input = horizontalInput;
        _spline = spline;
    }

    public void Enable()
    {
        _distance = 0f;

        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
    }

    private void Place()
    {
        CurveSample sample = _spline.GetSampleAtDistance(_distance);

        Vector3 right = sample.Rotation * Vector3.right;

        transform.localPosition = sample.location + right * _lateralOffset;
        transform.localRotation = sample.Rotation;
    }
}
