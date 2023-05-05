using UnityEngine;

public class ForceFieldController : WeaponController
{
    [SerializeField] protected float lifetime;
    [SerializeField] public float tick;
    [SerializeField] private Player player;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        Stance.Type color = Stance.GetRandomColor();
        GameObject field = Instantiate(prefab, transform.position, Quaternion.identity, transform);
        field.GetComponent<MeleeWeaponBehaviour>().Init(this, color, lifetime);
    }

    public override bool DoUpgrade(StatUpgrade statUp)
    {
        foreach (var up in statUp.upgradeToApplyList)
        {
            switch (up.stat)
            {
                case Stats.Stat.Unlock:
                    Unlock();
                    break;
                case Stats.Stat.Damage:
                    damage *= (int)up.value;
                    break;
                case Stats.Stat.Range:
                    range += up.value;
                    break;
                case Stats.Stat.Cooldown:
                    cooldown -= up.value;
                    break;
                case Stats.Stat.TickRate:
                    tick -= up.value;
                    if (cooldown <= minCooldown) {
                        cooldown = minCooldown;
                        return true;
                    }
                    break;
            }
        }
        return false;
    }

}
