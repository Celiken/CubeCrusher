using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance;

    [SerializeField] private bool isGamepad;

    public event EventHandler OnDeviceChanged;

    public event EventHandler<SwapEventArgs> OnSwap;
    public class SwapEventArgs : EventArgs
    {
        public int direction;
    }

    public InputActions inputActions;

    private PlayerInput pi;

    private void Awake()
    {
        Instance = this;

        pi = GetComponent<PlayerInput>();
        inputActions = new InputActions();
        inputActions.Player.Enable();

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        inputActions.Player.SwapNext.performed += SwapNext_performed;
        inputActions.Player.SwapPrev.performed += SwapPrev_performed;
    }

    private void SwapNext_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (Time.timeScale == 0f) return;
        OnSwap?.Invoke(this, new SwapEventArgs { direction = 1 });
    }
    private void SwapPrev_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (Time.timeScale == 0f) return;
        OnSwap?.Invoke(this, new SwapEventArgs { direction = -1 });
    }

    public Vector2 GetMovementNormalized()
    {
        return inputActions.Player.Move.ReadValue<Vector2>().normalized;
    }

    public void OnDeviceChange(PlayerInput pi)
    {
        isGamepad = pi.currentControlScheme.Equals("Gamepad") ? true : false;
        OnDeviceChanged?.Invoke(this, EventArgs.Empty);
        //if (isGamepad)
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
        //    Cursor.visible = false;
        //}
        //else
        //{
        //    Cursor.lockState = CursorLockMode.Confined;
        //    Cursor.visible = true;
        //}
    }

    public bool IsGamepad()
    {
        return isGamepad;
    }
}
