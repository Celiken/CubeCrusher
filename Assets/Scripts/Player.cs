using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    private XPManager xpManager;
    private CharacterController characterController;

    [SerializeField] private GameObject visual;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float moveSpeed;
    [SerializeField] private LayerMask layerPlayer;

    private Vector3 lastMoveDir;

    private ColorType.Color actualColor;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        Instance = this;
        lastMoveDir = Vector3.zero;
    }

    private void Start()
    {
        xpManager = XPManager.Instance;
        actualColor = ColorType.GetRandomColor();
        SwapRenderMat();
        gameInput.OnSwap += GameInput_OnSwap;
    }

    private void GameInput_OnSwap(object sender, GameInput.SwapEventArgs e)
    {
        actualColor = e.color;
        SwapRenderMat();
    }

    private void SwapRenderMat()
    {
        visual.GetComponent<Renderer>().material = ColorType.GetMaterialForColor(actualColor);
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

    public ColorType.Color GetActualColor()
    {
        return actualColor;
    }

    public void AddXP(int amount)
    {
        xpManager.AddXP(amount);
    }
}
