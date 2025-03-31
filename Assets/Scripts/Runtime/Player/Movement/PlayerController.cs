using UnityEngine;

using Zenject;

public class PlayerController : MonoBehaviour {
    [Inject] private InputManager _input;
    [Inject] private PlayerSettings _playerSettings;
    [Inject] private LevelSettings _levelSettings;
    private CharacterController _controller;
    private float _verticalVelocity;

    public float SpeedModifier => _input.IsCrouching ? _playerSettings.CrouchingModifier : 1;

    void Start() {
        _controller = GetComponent<CharacterController>();
    }

    void Update() {
        Move();
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
}
