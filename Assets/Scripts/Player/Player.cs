using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    public static Player Instance;

    private XPManager xpManager;
    private CharacterController characterController;

    public event EventHandler<VisualUpdateArgs> OnSwapVisualUpdate;
    public class VisualUpdateArgs : EventArgs
    {
        public Stance.Type newStance;
    }

    [SerializeField] private GameObject visual;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float gamepadSensitivity;
    [SerializeField] private LayerMask groundMask;

    private Vector3 lastMoveDir;

    private Stance.Type actualColor;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        Instance = this;
        lastMoveDir = Vector3.zero;
    }

    private void Start()
    {
        xpManager = XPManager.Instance;
        actualColor = Stance.GetRandomColor();
        SwapRenderMat();
        gameInput.OnSwap += GameInput_OnSwap;
    }

    private void GameInput_OnSwap(object sender, GameInput.SwapEventArgs e)
    {
        actualColor = Stance.GetNextColor(actualColor, e.direction);
        SwapRenderMat();
    }

    private void SwapRenderMat()
    {
        visual.GetComponent<Renderer>().material = Stance.GetPlayerMaterialForColor(actualColor);
        OnSwapVisualUpdate?.Invoke(this, new VisualUpdateArgs { newStance = actualColor });
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 input = gameInput.GetMovementNormalized();
        Vector3 moveDir = new Vector3(input.x, 0f, input.y);
        float moveDistance = moveSpeed * Time.deltaTime;
        characterController.Move(moveDir * moveDistance);
        lastMoveDir = moveDir;
    }

    public Vector3 GetLastMoveDir()
    {
        return lastMoveDir;
    }

    public Stance.Type GetActualColor()
    {
        return actualColor;
    }

    public void AddXP(int amount)
    {
        xpManager.AddXP(amount);
    }
}
