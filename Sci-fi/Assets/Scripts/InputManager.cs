using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions OnFoot;
    public PlayerInput.UIActions UI;
    private PlayerMotor motor;
    private PlayerLook look;

    void Awake()
    {
        playerInput = new PlayerInput();
        OnFoot = playerInput.OnFoot;
        UI = playerInput.UI;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        OnFoot.Jump.performed += ctx => motor.Jump();

        OnFoot.Crounch.performed += ctx => motor.Crouch();
        OnFoot.Sprint.performed += ctx => motor.Sprint();
    }

    public void SwitchActionMap()
    {
        if (OnFoot.enabled)
        {
            OnFoot.Disable();
            UI.Enable();
        }
        else
        {
            OnFoot.Enable();
            UI.Disable();
        }
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
