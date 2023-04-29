using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    private XPManager xpManager;

    [SerializeField] private GameObject visual;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float moveSpeed;

    private Vector3 lastMoveDir;

    private SphereCollider playerCollider;

    private ColorType.Color actualColor;

    private void Awake()
    {
        Instance = this;
        playerCollider = GetComponent<SphereCollider>();
        lastMoveDir = Vector3.zero;
    }

    private void Start()
    {
        xpManager = XPManager.Instance;
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
        transform.position += moveDir * moveDistance;
        lastMoveDir = moveDir;
    }

    public Vector3 GetLastMoveDir()
    {
        return lastMoveDir;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (enemy.GetColor() == actualColor)
            {
                enemy.Kill();
            }
        }
    }

    public void AddXP(int amount)
    {
        xpManager.AddXP(amount);
    }
}
