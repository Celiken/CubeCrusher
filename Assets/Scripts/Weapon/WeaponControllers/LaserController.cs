using System.Collections.Generic;
using UnityEngine;

public class LaserController : WeaponController
{
    [Header("Speed")]
    public float Speed;
    [Header("Pierce")]
    [SerializeField] private int basePierce;
    public int Pierce;

    public List<Enemy> closestEnemies;

    protected override void Start()
    {
        ComputeValues();
        base.Start();
    }

    protected override void Attack()
    {
        Stance.Type color = player.GetActualColor();
        closestEnemies = EnemyTargeter.Instance.GetClosestEnemies(color, player.GetStats().GetStatComponent<AmountStat>(Stats.EntityStat.Amount).GetIntLeveledValue());
        if (closestEnemies != null && closestEnemies.Count != 0)
        {
            foreach (Enemy enemy in closestEnemies)
            {
                float dist = (enemy.transform.position - player.transform.position).magnitude;
                if (dist <= Range)
                {
                    GameObject projectile = Instantiate(prefab);
                    projectile.transform.position = transform.position;
                    projectile.GetComponent<ProjectileWeaponBehaviour>().Init(this, (enemy.transform.position - player.transform.position).normalized, Range / Speed, color);
                    base.Attack();
                }
            }
        }
    }

    public override void ComputeValues()
    {
        Pierce = basePierce + player.GetStats().GetStatComponent<PiercingStat>(Stats.EntityStat.Piercing).GetIntLeveledValue();
        base.ComputeValues();
    }
}