using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] private GameObject visual;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float moveSpeed;

    private Vector3 lastMoveDir;

    private ColorType.Color actualColor;

    private void Awake()
    {
        Instance = this;
        lastMoveDir = Vector3.zero;
    }

    private void Start()
    {
        actualColor = ColorType.GetRandomColor();
        SwapRenderMat();
        gameInput.OnSwitch += GameInput_OnSwitch;
    }

    private void GameInput_OnSwitch(object sender, System.EventArgs e)
    {
        actualColor = ColorType.GetNextColor(actualColor);
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
        float playerRadius = 1f;
        float playerHeight = 1f;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);
        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = (moveDir.x < -.5f || moveDir.x > .5f) && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
            if (canMove)
                moveDir = moveDirX;
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = (moveDir.z < -.5f || moveDir.z > .5f) && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
                if (canMove)
                    moveDir = moveDirZ;
            }
        }
        if (canMove)
        {
            transform.position += moveDir * moveDistance;
            lastMoveDir = moveDir;
        }
    }

    public Vector3 GetLastMoveDir()
    {
        return lastMoveDir;
    }
}
