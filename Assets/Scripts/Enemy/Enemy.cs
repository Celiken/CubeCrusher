using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform damagePosition;
    
    [SerializeField] private float moveSpeed;
    
    [SerializeField] private float attackRange;
    [SerializeField] private float attackCooldown;

    private float timerAttack;

    [SerializeField] private GameObject visual;

    [SerializeField] private int xpMinAmount;
    [SerializeField] private int xpMaxAmount;

    [SerializeField] LayerMask layerEnemy;

    [SerializeField] private float approxDistance;
    [SerializeField] private float timerApproxMax;

    private Vector3 positionApprox = Vector3.zero;
    private float timerApprox;

    private Player playerTarget;
    private CharacterController characterController;
    private StatsManager statManager;

    private Stance.Type color;

    private void Awake()
    {
        statManager = GetComponent<StatsManager>();
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        timerAttack = attackCooldown;
        playerTarget = Player.Instance;
        color = Stance.GetRandomColor();
        EnemyTargeter.Instance.AddEnemy(this);
        ChangeRender();
        timerApprox = 0f;
    }

    void Update()
    {
        timerAttack -= Time.deltaTime;
        timerApprox -= Time.deltaTime;
        if (timerApprox <= 0f)
        {
            RefreshTargetApprox();
            timerApprox = timerApproxMax;
        }
        Move();
        AttackIfPlayerInRange();
    }

    private void AttackIfPlayerInRange()
    {
        Vector3 targetDir = (playerTarget.transform.position - transform.position);
        if (targetDir.magnitude <= attackRange && timerAttack <= 0f)
        {
            timerAttack = attackCooldown;
            playerTarget.TakeDamage(statManager.GetStatComponent<BaseDamageStat>(Stats.EntityStat.BaseDamage).GetBaseDamage());
        }
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
        visual.GetComponent<Renderer>().material = Stance.GetEnemyMaterial(color);
    }

    public Stance.Type GetActualColor()
    {
        return color;
    }

    public void Hit(int damage)
    {
        DamagePopupUI.Create(damagePosition.position, damage, color);
        visual.GetComponent<EntityVisual>().GetHit();
        if (statManager.GetStatComponent<LifeStat>(Stats.EntityStat.Life).TakeDamage(damage) <= 0)
            DestroySelf();
    }

    public void DestroySelf()
    {
        XPManager.Instance.SpawnXP(transform, Random.Range(xpMinAmount, xpMaxAmount + 1));
        EnemyTargeter.Instance.RemoveEnemy(this);
        GameManager.Instance.AddKill();
        Destroy(gameObject);
    }
}
