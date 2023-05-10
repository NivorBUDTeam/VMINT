using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions OnFoot;
    private PlayerMotor motor;
    private PlayerLook look;

    void Awake()
    {
        playerInput = new PlayerInput();
        OnFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        OnFoot.Jump.performed += ctx => motor.Jump();

        OnFoot.Crounch.performed += ctx => motor.Crouch();
        OnFoot.Sprint.performed += ctx => motor.Sprint();
    }

    void FixedUpdate()
    {
        motor.ProcessMove(OnFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(OnFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        OnFoot.Enable();
    }

    private void OnDisable()
    {
        OnFoot.Disable();
    }
}
