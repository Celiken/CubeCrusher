using UnityEngine;

public class LaserController : WeaponController
{
    [Header("Speed")]
    [SerializeField] public float speed;
    [Header("Pierce")]
    [SerializeField] public int pierce;

    protected override void Attack()
    {
        Stance.Type color = player.GetActualColor();
        Enemy closestEnemy = EnemyTargeter.Instance.GetClosestEnemy(color);
        if (closestEnemy != null)
        {
            float dist = (closestEnemy.transform.position - player.transform.position).magnitude;
            if (dist <= range)
            {
                base.Attack();
                GameObject projectile = Instantiate(prefab);
                projectile.transform.position = transform.position;
                projectile.GetComponent<ProjectileWeaponBehaviour>().Init(this, (closestEnemy.transform.position - player.transform.position).normalized, range / speed, color);
            }
        }
    }

    public override bool DoUpgrade(WeaponStatUpgrade statUp)
    {
        foreach (var up in statUp.upgradeToApplyList)
        {
            switch (up.stat)
            {
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
                case Stats.WeaoponStat.Pierce:
                    pierce += (int)up.value;
                    break;
                case Stats.WeaoponStat.Cooldown:
                    cooldown -= up.value;
                    if (cooldown <= minCooldown)
                    {
                        cooldown = minCooldown;
                        return true;
                    }
                    break;
            }
        }
        return false;
    }
}