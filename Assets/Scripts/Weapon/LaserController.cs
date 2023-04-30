using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : WeaponBase
{
    [SerializeField] private Player player;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();        
    }

    protected override void Attack()
    {
        ColorType.Color color = player.GetActualColor();
        Enemy closestEnemy = EnemyTargeter.Instance.GetClosestEnemy(color);
        if (closestEnemy != null)
        {
            base.Attack();
            GameObject projectile = Instantiate(prefab);
            projectile.transform.position = transform.position;
            projectile.GetComponent<ProjectileWeaponBehaviour>().Init((closestEnemy.transform.position - player.transform.position).normalized, speed, color);
        }
    }
}
