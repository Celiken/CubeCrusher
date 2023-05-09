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

    public override bool DoUpgrade(WeaponUpgradeSO.WeaponIncrease upgrade)
    {
        switch (upgrade.stat)
        {
            case Stats.WeaponStat.Pierce:
                pierce += (int)upgrade.value;
                break;
            default:
                return base.DoUpgrade(upgrade);
        }
        return false;
    }
}