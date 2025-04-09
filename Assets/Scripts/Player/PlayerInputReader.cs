using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }

    private PlayerControls _playerControls;

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
        _playerControls.InGame.Movement.performed += OnMovementPerformed;
        _playerControls.InGame.Movement.canceled += OnMovementCanceled;
    }

    private void OnDisable()
    {
        _playerControls.InGame.Movement.performed -= OnMovementPerformed;
        _playerControls.InGame.Movement.canceled -= OnMovementCanceled;
        _playerControls.Disable();
    }

    private void OnMovementPerformed(InputAction.CallbackContext ctx)
    {
        MoveInput = ctx.ReadValue<Vector2>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext ctx)
    {
        MoveInput = Vector2.zero;
    }
}