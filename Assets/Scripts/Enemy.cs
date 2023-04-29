using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float minMoveSpeed;
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float distanceSlow;

    [SerializeField] private GameObject visualGO;

    [SerializeField] private float xpSpread;
    [SerializeField] private int xpMinAmount;
    [SerializeField] private int xpMaxAmount;

    [SerializeField] LayerMask layerMoveEnemy;

    private GameInput gameInput;
    private Player playerTarget;

    private float moveSpeed;
    private ColorType.Color color;

    private void Awake()
    {
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    void Start()
    {
        playerTarget = Player.Instance;
        gameInput = GameInput.Instance;
        color = ColorType.GetRandomColor();
        ChangeRender();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTarget.transform.position, moveSpeed * Time.deltaTime);
    }

    private void ChangeRender()
    {
        visualGO.GetComponent<Renderer>().material = ColorType.GetMaterialForColor(color);
    }

    public ColorType.Color GetColor()
    {
        return color;
    }

    public void Kill()
    {
        SpawnXP();
        Destroy(gameObject);
    }

    public void SpawnXP()
    {
        int xpAmount = Random.Range(xpMinAmount, xpMaxAmount + 1);
        for (int i = 0; i < xpAmount; i++)
        {
            Instantiate(GameAssets.Instance.xpPrefab, transform.position + new Vector3(Random.Range(-xpSpread, xpSpread), 0f, Random.Range(-xpSpread, xpSpread)), Quaternion.identity);
        }
    }
}
