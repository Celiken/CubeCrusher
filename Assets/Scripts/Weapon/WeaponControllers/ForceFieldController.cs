using UnityEngine;

public class ForceFieldController : WeaponController
{
    [Header("TickRate")]
    [SerializeField] protected float minTickRate;
    [SerializeField] public float tickRate;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        Stance.Type color = Stance.GetRandomColor();
        GameObject field = Instantiate(prefab, transform.position, Quaternion.identity, transform);
        field.GetComponent<MeleeWeaponBehaviour>().Init(this, color, cooldown);
    }

    public override bool DoUpgrade(WeaponStatUpgrade statUp) // return true if maxed
    {
        foreach (var up in statUp.upgradeToApplyList)
        {
            switch (up.stat)
            {
                case Stats.WeaoponStat.Unlock:
                    Unlock();
                    break;
                case Stats.WeaoponStat.Damage:
                    damage += (int)up.value;
                    break;
                case Stats.WeaoponStat.Range:
                    range += up.value;
                    if (range >= maxRange)
                    {
                        range = maxRange;
                        return true;
                    }
                    break;
                case Stats.WeaoponStat.Cooldown:
                    cooldown -= up.value;
                    if (cooldown <= minCooldown)
                    {
                        cooldown = minCooldown;
                        return true;
                    }
                    break;
                case Stats.WeaoponStat.TickRate:
                    tickRate -= up.value;
                    if (tickRate <= minTickRate) {
                        tickRate = minTickRate;
                        return true;
                    }
                    break;
            }
        }
        return false;
    }

}
