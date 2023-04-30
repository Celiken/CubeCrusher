using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private GameObject visualGO;

    [SerializeField] private float xpSpread;
    [SerializeField] private int xpMinAmount;
    [SerializeField] private int xpMaxAmount;

    [SerializeField] LayerMask layerEnemy;

    [SerializeField] private float approxDistance;
    [SerializeField] private float timerApproxMax;
    private Vector3 positionApprox = Vector3.zero;
    private float timerApprox;

    private Player playerTarget;
    private CharacterController characterController;

    private ColorType.Color color;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        playerTarget = Player.Instance;
        color = ColorType.GetRandomColor();
        EnemyTargeter.Instance.AddEnemy(this);
        ChangeRender();
        timerApprox = 0f;
    }

    void Update()
    {
        timerApprox -= Time.deltaTime;
        if (timerApprox <= 0f)
        {
            RefreshTargetApprox();
            timerApprox = timerApproxMax;
        }
        Move();
    }

    private void Move()
    {
        Vector3 moveDir = (playerTarget.transform.position - (transform.position + positionApprox)).normalized;

        float moveDistance = moveSpeed * Time.deltaTime;

        characterController.Move(moveDir * moveDistance);
    }

    private void RefreshTargetApprox()
    {
        positionApprox = new Vector3(Random.Range(-approxDistance, approxDistance), 0f, Random.Range(-approxDistance, approxDistance));
    }

    private void ChangeRender()
    {
        visualGO.GetComponent<Renderer>().material = ColorType.GetMaterialForColor(color);
    }

    public ColorType.Color GetActualColor()
    {
        return color;
    }

    public void DestroySelf()
    {
        SpawnXP();
        EnemyTargeter.Instance.RemoveEnemy(this);
        Destroy(gameObject);
    }

    public void SpawnXP()
    {
        int xpAmount = Random.Range(xpMinAmount, xpMaxAmount + 1);
        for (int i = 0; i < xpAmount; i++)
        {
            Instantiate(GameAssets.Instance.xpPrefab, transform.position + new Vector3(Random.Range(-xpSpread, xpSpread), -.5f, Random.Range(-xpSpread, xpSpread)), Quaternion.identity);
        }
    }
}
