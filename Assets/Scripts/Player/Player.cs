using DG.Tweening;
using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    public static Player Instance;

    private XPManager xpManager;
    private StatsManager statManager;
    private CharacterController characterController;

    public event EventHandler<VisualUpdateArgs> OnSwapVisualUpdate;
    public class VisualUpdateArgs : EventArgs
    {
        public Stance.Type newStance;
    }

    [SerializeField] private GameObject visual;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float gamepadSensitivity;
    [SerializeField] private LayerMask groundMask;

    private Vector3 lastMoveDir;

    private Stance.Type actualColor;

    private void Awake()
    {
        statManager = GetComponent<StatsManager>();
        characterController = GetComponent<CharacterController>();
        Instance = this;
        lastMoveDir = Vector3.zero;
    }

    private void Start()
    {
        xpManager = XPManager.Instance;
        actualColor = Stance.GetRandomColor();
        SwapRenderMat();
        statManager.InitLevel(0);
        gameInput.OnSwap += GameInput_OnSwap;
    }

    private void GameInput_OnSwap(object sender, GameInput.SwapEventArgs e)
    {
        actualColor = Stance.GetNextColor(actualColor, e.direction);
        SwapRenderMat();
    }

    private void SwapRenderMat()
    {
        visual.GetComponent<EntityVisual>().ChangeColor(actualColor);
        //visual.GetComponent<Renderer>().material = Stance.GetPlayerMaterial(actualColor);
        OnSwapVisualUpdate?.Invoke(this, new VisualUpdateArgs { newStance = actualColor });
    }

    void Update()
    {
        Move();
    }

    public void TakeDamage(float damage)
    {
        statManager.GetStatComponent<LifeStat>(Stats.EntityStat.Life).TakeDamage(Mathf.RoundToInt(damage - statManager.GetStatComponent<ArmorStat>(Stats.EntityStat.Armor).GetBaseValue()));
        visual.GetComponent<EntityVisual>().GetHit();
    }

    private void Move()
    {
        Vector2 input = gameInput.GetMovementNormalized();
        Vector3 moveDir = new Vector3(input.x, 0f, input.y);
        float moveDistance = statManager.GetStatComponent<MoveSpeedStat>(Stats.EntityStat.MoveSpeed).GetBaseValue() * Time.deltaTime;
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

    public int GetLevel()
    {
        return xpManager.GetLevel();
    }

    public StatsManager GetStats() { return statManager; }
}
