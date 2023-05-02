using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : WeaponController
{
    [SerializeField] private float distance;
    [SerializeField] private Player player;

    protected override void Attack()
    {
        Stance.Type color = player.GetActualColor();
        Vector3 dir = player.transform.forward;
        base.Attack();
        GameObject projectile = Instantiate(prefab);
        projectile.transform.position = transform.position;
        projectile.GetComponent<ProjectileWeaponBehaviour>().Init(this, dir, distance / speed, color);
    }
}

// Closest enemy target
//Stance.Type color = player.GetActualColor();
//Enemy closestEnemy = EnemyTargeter.Instance.GetClosestEnemy(color);
//if (closestEnemy != null)
//{
//    float dist = (closestEnemy.transform.position - player.transform.position).magnitude;
//    if (dist <= distance)
//    {
//        base.Attack();
//        GameObject projectile = Instantiate(prefab);
//        projectile.transform.position = transform.position;
//        projectile.GetComponent<ProjectileWeaponBehaviour>().Init(this, (closestEnemy.transform.position - player.transform.position).normalized, distance / speed, color);
//    }
//}
