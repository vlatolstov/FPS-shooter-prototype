using UnityEngine;

using Zenject;

public class CameraController : MonoBehaviour {
    [Inject] private CameraSettings _settings;
    [Inject] private InputManager _input;
    [SerializeField] private Transform _playerTransform;

    private float xRotation = 0;

    private void LateUpdate() {
        RotateCamera();
    }

    private void RotateCamera() {
        Vector3 mouseInput = _settings.MouseSensitivity * Time.deltaTime * _input.GetMouseInput();
        float mouseX = mouseInput.x;
        float mouseY = mouseInput.y;

        _playerTransform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        Vector3 eulerAngles = transform.localEulerAngles;
        eulerAngles.x = xRotation;
        transform.localEulerAngles = eulerAngles;
    }
}
