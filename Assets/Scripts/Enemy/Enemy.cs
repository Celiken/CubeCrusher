using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform damagePosition;
        
    [SerializeField] private float attackRange;
    [SerializeField] private float attackCooldown;

    private float timerAttack;

    [SerializeField] private GameObject visual;

    [SerializeField] private int xpMinAmount;
    [SerializeField] private int xpMaxAmount;

    [SerializeField] LayerMask layerEnemy;

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
        statManager.InitLevel(Player.Instance.GetLevel());
    }

    void Update()
    {
        timerAttack -= Time.deltaTime;
        Move();
        AttackIfPlayerInRange();
    }

    private void AttackIfPlayerInRange()
    {
        Vector3 targetDir = (playerTarget.transform.position - transform.position);
        if (targetDir.magnitude <= attackRange && timerAttack <= 0f)
        {
            timerAttack = attackCooldown;
            bool isCrit = statManager.GetStatComponent<CritRateStat>(Stats.EntityStat.CritRate).IsCrit();
            float baseDmg = statManager.GetStatComponent<BaseDamageStat>(Stats.EntityStat.BaseDamage).GetBaseValue();
            float critDmg = statManager.GetStatComponent<CritDamageStat>(Stats.EntityStat.CritDamage).GetBaseValue();
            playerTarget.TakeDamage(isCrit ? baseDmg * critDmg : baseDmg);
        }
    }

    private void Move()
    {
        Vector3 moveDir = (playerTarget.transform.position - transform.position).normalized;

        float moveDistance = statManager.GetStatComponent<MoveSpeedStat>(Stats.EntityStat.MoveSpeed).GetBaseValue() * Time.deltaTime;

        characterController.Move(moveDir * moveDistance);
    }

    private void ChangeRender()
    {
        visual.GetComponent<EntityVisual>().ChangeColor(color);
    }

    public Stance.Type GetActualColor()
    {
        return color;
    }

    public void Hit(float damage, bool isCrit)
    {
        int finalDmg = Mathf.RoundToInt(damage - statManager.GetStatComponent<ArmorStat>(Stats.EntityStat.Armor).GetBaseValue());
        DamagePopupUI.Create(damagePosition.position, finalDmg, color, isCrit);
        visual.GetComponent<EntityVisual>().GetHit();
        if (statManager.GetStatComponent<LifeStat>(Stats.EntityStat.Life).TakeDamage(finalDmg) <= 0)
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
