using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : WeaponController
{
    [SerializeField] private float distance;
    [SerializeField] private Player player;

    protected override void Attack()
    {
        ColorType.Color color = player.GetActualColor();
        Enemy closestEnemy = EnemyTargeter.Instance.GetClosestEnemy(color);
        if (closestEnemy != null)
        {
            float dist = (closestEnemy.transform.position - player.transform.position).magnitude;
            if (dist <= distance)
            {
                base.Attack();
                GameObject projectile = Instantiate(prefab);
                projectile.transform.position = transform.position;
                projectile.GetComponent<ProjectileWeaponBehaviour>().Init(this, (closestEnemy.transform.position - player.transform.position).normalized, distance / speed, color);
            }
        }
    }
}
