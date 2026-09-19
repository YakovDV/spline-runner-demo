using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _trackingPoint;

    [SerializeField] private Vector3 _cameraOffset;
    [SerializeField] private Vector3 _cameraAngle;

    private void OnEnable()
    {
        _camera.transform.position = _cameraOffset;
        _camera.transform.rotation = Quaternion.Euler(_cameraAngle);
    }

    private void LateUpdate()
    {
        Quaternion yaw = Quaternion.Euler(0f, _trackingPoint.eulerAngles.y, 0f);

        Vector3 position = _trackingPoint.position + yaw * _cameraOffset;

        _camera.transform.position = position;
        _camera.transform.rotation = Quaternion.Euler(_cameraAngle.x, _trackingPoint.eulerAngles.y, _cameraAngle.z);
    }

    public void SetTrackingPoint(Transform target)
    {
        _trackingPoint = target;
    }
}
