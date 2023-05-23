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
    [SerializeField] private int levelWeapon = 0;
    [Header("Cooldown")]
    [SerializeField] protected float baseCooldown;
    [SerializeField] protected float minCooldown;
    public float Cooldown;
    [Header("Range")]
    [SerializeField] protected float baseRange;
    [SerializeField] protected float maxRange;
    public float Range;
    [Header("Damage")]
    [SerializeField] protected float baseDamage;
    [SerializeField] private float damageFactor;
    public float Damage;

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
        timeBeforeNextAttack = Cooldown;
    }

    public bool DoUpgrade()
    {
        if (!unlock)
            Unlock();
        else
            levelWeapon++;
        return levelWeapon == 10;
    }

    public float GetDamage()
    {
        return Damage;
    }

    public virtual void ComputeValues()
    {
        Cooldown = baseCooldown * (1f - player.GetStats().GetStatComponent<CooldownStat>(Stats.EntityStat.Cooldown).GetBaseValue());
        Range = baseRange * player.GetStats().GetStatComponent<RangeStat>(Stats.EntityStat.Range).GetBaseValue();
        Damage = (baseDamage * Mathf.Pow(damageFactor, levelWeapon)) * player.GetStats().GetStatComponent<DamageMultStat>(Stats.EntityStat.DamageMult).GetBaseValue();
    }

    public int GetWeaponLevel()
    {
        return levelWeapon;
    }
}
