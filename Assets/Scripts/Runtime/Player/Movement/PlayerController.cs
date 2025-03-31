using Unity.VisualScripting;

using UnityEngine;

using Zenject;

public class PlayerController : MonoBehaviour {
    [Inject] private InputManager _input;
    [Inject] private PlayerSettings _playerSettings;
    [Inject] private LevelSettings _levelSettings;
    private CharacterController _controller;
    private float _verticalVelocity;

    private float _originalHeight;
    private Vector3 _originalCenter;
    private bool _isCrouching;
    private Vector3 _crouchCenter;

    public float SpeedModifier => _isCrouching ? _playerSettings.CrouchingModifier : 1;

    void Start() {
        _controller = GetComponent<CharacterController>();
        _originalHeight = _controller.height;
        _originalCenter = _controller.center;
        _crouchCenter = new(_originalCenter.x, _originalCenter.y / 2, _originalCenter.z);
    }

    void Update() {
        Move();
        CheckCrouching();
    }

    private void Move() {

        if (_controller.isGrounded && _verticalVelocity < 0) {
            _verticalVelocity = -2f;
        }

        if (_controller.isGrounded && _input.IsJumping) {
            _verticalVelocity = Mathf.Sqrt(_playerSettings.JumpHeight * -2f * _levelSettings.Gravity) * SpeedModifier;
        }

        _verticalVelocity += _levelSettings.Gravity * Time.deltaTime;

        var movementVelocity = transform.TransformDirection(_input.GetMovementInput()) * _playerSettings.MovementSpeed * SpeedModifier;
        movementVelocity.y = _verticalVelocity;
        _controller.Move(movementVelocity * Time.deltaTime);
    }

    private void CheckCrouching() {
        if (_input.IsCrouching) {
            _isCrouching = true;
        }
        else {
            if (CanStandUp()) {
                _isCrouching = false;
            }
        }

        SmoothCrouching();
    }

    private bool CanStandUp() {
        Vector3 checkPosition = transform.position + Vector3.up * (_originalHeight / 2);
        float checkRadius = _controller.radius;
        bool blocked = Physics.CheckSphere(checkPosition, checkRadius, ~LayerMask.GetMask("Player"));
        return !blocked;
    }

    private void SmoothCrouching() {
        float targetHeight = _isCrouching ? _originalHeight / 2 : _originalHeight;
        Vector3 targetCenter = _isCrouching ? _crouchCenter : _originalCenter;

        _controller.height = Mathf.Lerp(_controller.height, targetHeight, _playerSettings.CrouchTransitionSpeed * Time.deltaTime);
        _controller.center = Vector3.Lerp(_controller.center, targetCenter, _playerSettings.CrouchTransitionSpeed * Time.deltaTime);
    }
}
