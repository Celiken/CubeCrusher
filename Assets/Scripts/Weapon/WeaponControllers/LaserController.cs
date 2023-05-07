using UnityEngine;

public class LaserController : WeaponController
{
    [SerializeField] public int pierce;
    [SerializeField] private Player player;

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
        //Stance.Type color = player.GetActualColor();
        //Vector3 dir = player.transform.forward;
        //base.Attack();
        //GameObject projectile = Instantiate(prefab);
        //projectile.transform.position = transform.position;
        //projectile.GetComponent<ProjectileWeaponBehaviour>().Init(this, dir, range / speed, color);
    }

    public override bool DoUpgrade(StatUpgrade statUp)
    {
        foreach (var up in statUp.upgradeToApplyList)
        {
            switch (up.stat)
            {
                case Stats.Stat.Damage:
                    damage *= (int)up.value;
                    break;
                case Stats.Stat.Range:
                    range += up.value;
                    break;
                case Stats.Stat.Pierce:
                    pierce += (int)up.value;
                    break;
                case Stats.Stat.Cooldown:
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

// Closest enemy target

