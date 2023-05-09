using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] public WeaponsManager.WeaponType type;
    [SerializeField] protected GameObject prefab;
    [SerializeField] public bool unlock;

    [Header("Player")]
    [SerializeField] protected Player player;

    [Header("Weapon Stats")]
    [Header("Cooldown")]
    [SerializeField] protected float minCooldown;
    [SerializeField] public float cooldown;
    [Header("Range")]
    [SerializeField] protected float maxRange;
    [SerializeField] public float range;
    [Header("Damage")]
    [SerializeField] public int damage;

    private float timeBeforeNextAttack;

    private void Awake()
    {
        gameObject.SetActive(unlock);
    }

    protected virtual void Start()
    {
        timeBeforeNextAttack = 0f;
    }

    protected virtual void Update()
    {
        timeBeforeNextAttack -= Time.deltaTime;
        if (timeBeforeNextAttack <= 0f)
        {
            timeBeforeNextAttack = 0f;
            Attack();
        }
    }

    protected virtual void Unlock()
    {
        unlock = true;
        gameObject.SetActive(unlock);
        timeBeforeNextAttack = 0f;
    }

    protected virtual void Attack()
    {
        timeBeforeNextAttack = cooldown;
    }

    public virtual bool DoUpgrade(WeaponUpgradeSO.WeaponIncrease upgrade)
    {
        switch (upgrade.stat)
        {
            case Stats.WeaponStat.Unlock:
                Unlock();
                break;
            case Stats.WeaponStat.Damage:
                damage += (int)upgrade.value;
                break;
            case Stats.WeaponStat.Range:
                range += upgrade.value;
                if (range >= maxRange)
                {
                    range = maxRange;
                    return true;
                }
                break;
            case Stats.WeaponStat.Cooldown:
                cooldown -= upgrade.value;
                if (cooldown <= minCooldown)
                {
                    cooldown = minCooldown;
                    return true;
                }
                break;
        }
        return false;
    }
}
