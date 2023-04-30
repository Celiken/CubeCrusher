using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance;

    public event EventHandler<SwapEventArgs> OnSwap;
    public class SwapEventArgs : EventArgs
    {
        public ColorType.Color color;
    }

    InputActions inputActions;

    private void Awake()
    {
        Instance = this;

        inputActions = new InputActions();
        inputActions.Player.Enable();

        inputActions.Player.SwapBlue.performed += SwapBlue_performed;
        inputActions.Player.SwapRed.performed += SwapRed_performed;
        inputActions.Player.SwapGreen.performed += SwapGreen_performed;
        inputActions.Player.SwapYellow.performed += SwapYellow_performed;
    }

    private void SwapBlue_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnSwap?.Invoke(this, new SwapEventArgs { color = ColorType.Color.Blue });
    }
    private void SwapRed_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnSwap?.Invoke(this, new SwapEventArgs { color = ColorType.Color.Red });
    }
    private void SwapGreen_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnSwap?.Invoke(this, new SwapEventArgs { color = ColorType.Color.Green });
    }
    private void SwapYellow_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnSwap?.Invoke(this, new SwapEventArgs { color = ColorType.Color.Yellow });
    }

    public Vector2 GetMovementNormalized()
    {
        return inputActions.Player.Move.ReadValue<Vector2>().normalized;
    }
}
