using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance;

    public event EventHandler OnSwitch;

    InputActions inputActions;

    private void Awake()
    {
        Instance = this;

        inputActions = new InputActions();
        inputActions.Player.Enable();

        inputActions.Player.Switch.performed += Switch_performed;
    }

    private void Switch_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnSwitch?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementNormalized()
    {
        return inputActions.Player.Move.ReadValue<Vector2>().normalized;
    }
}
