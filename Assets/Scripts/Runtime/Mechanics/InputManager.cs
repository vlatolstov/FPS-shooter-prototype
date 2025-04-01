using UnityEngine;

public class InputManager : MonoBehaviour {
    private float _horizontalInput;
    private float _verticalInput = 0;
    private float _mouseX = 0;
    private float _mouseY = 0;
    private bool _jump = false;
    private bool _crouch = false;
    private bool _isShooting = false;
    private bool _isUsing = false;
    private bool _needToReload = false;


    void Update() {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");

        _jump = Input.GetKeyDown(KeyCode.Space);
        _crouch = Input.GetKey(KeyCode.LeftControl);
        _isShooting = Input.GetMouseButton(0);
        _isUsing = Input.GetKeyDown(KeyCode.E);
        _needToReload = Input.GetKeyDown(KeyCode.R);
    }

    public bool IsJumping => _jump;
    public bool IsCrouching => _crouch;
    public bool IsShooting => _isShooting;
    public bool IsUsing => _isUsing;
    public bool NeedToReload => _needToReload; 

    public Vector3 GetMovementInput() => Vector3.ClampMagnitude(new(_horizontalInput, 0, _verticalInput), 1);
    public Vector3 GetMouseInput() => Vector3.ClampMagnitude(new(_mouseX, _mouseY, 0), 1);
}
