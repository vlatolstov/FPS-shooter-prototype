using UnityEngine;
using UnityEngine.UI;

using Zenject;

public class PlayerController : MonoBehaviour {
    [Inject] private InputManager _input;
    [Inject] private PlayerSettings _playerSettings;
    [Inject] private LevelSettings _levelSettings;
    private CharacterController _controller;
    private PlayerWeaponController _weaponController;
    private Camera _camera;
    private float _verticalVelocity;

    private float _originalHeight;
    private Vector3 _originalCenter;
    private bool _isCrouching;
    private Vector3 _crouchCenter;

    [SerializeField] private Text _tooltipText;

    public float SpeedModifier => _isCrouching ? _playerSettings.CrouchingModifier : 1;

    void Start() {
        _controller = GetComponent<CharacterController>();
        _weaponController = GetComponent<PlayerWeaponController>();
        _camera = GetComponentInChildren<Camera>();
        _originalHeight = _controller.height;
        _originalCenter = _controller.center;
        _crouchCenter = new(_originalCenter.x, _originalCenter.y / 2, _originalCenter.z);

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        UpdateTooltip();
        Move();
        CheckCrouching();

        if (_input.IsShooting) {
            Shoot();
        }

        CheckFrontalRaycast();
    }

    private void Move() {

        if (_controller.isGrounded && _verticalVelocity < 0) {
            _verticalVelocity = -2f;
        }

        if (_controller.isGrounded && _input.IsJumping && CanFitInShiftedPosition(Vector3.up * _playerSettings.JumpHeight)) {
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
            if (CanFitInShiftedPosition(Vector3.up * (_originalHeight / 2))) {
                _isCrouching = false;
            }
        }

        SmoothCrouching();
    }

    private bool CanFitInShiftedPosition(Vector3 positionDelta) {
        Vector3 checkPosition = transform.position + positionDelta;
        float checkRadius = _controller.radius - 0.05f;
        bool blocked = Physics.CheckSphere(checkPosition, checkRadius, ~LayerMask.GetMask("Player"));
        return !blocked;
    }

    private void SmoothCrouching() {
        float targetHeight = _isCrouching ? _originalHeight / 2 : _originalHeight;
        Vector3 targetCenter = _isCrouching ? _crouchCenter : _originalCenter;

        _controller.height = Mathf.Lerp(_controller.height, targetHeight, _playerSettings.CrouchTransitionSpeed * Time.deltaTime);
        _controller.center = Vector3.Lerp(_controller.center, targetCenter, _playerSettings.CrouchTransitionSpeed * Time.deltaTime);
    }

    private void Shoot() {
        var weapon = _weaponController.CurrentWeapon;
        weapon?.Attack(_camera.transform.position, _camera.transform.forward);
    }

    void CheckFrontalRaycast() {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, 3f)) {
            var pickup = hit.collider.GetComponent<PickupProcessor>();
            if (pickup != null) {
                UpdateTooltip(pickup.GetPickupInfo());

                if (_input.IsUsing) {
                    pickup.Pickup(gameObject);
                }
            }
        }
    }

    void UpdateTooltip(string text = null) {
        if (string.IsNullOrEmpty(text)) {
            _tooltipText.text = "";
            _tooltipText.gameObject.SetActive(false);
        }

        else {
            _tooltipText.text = text;
            _tooltipText.gameObject.SetActive(true);
        }
    }
}
