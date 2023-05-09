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

    public override bool DoUpgrade(WeaponUpgradeSO.WeaponIncrease upgrade)
    {
        switch (upgrade.stat)
        {
            case Stats.WeaponStat.TickRate:
                tickRate -= upgrade.value;
                if (tickRate <= minTickRate)
                {
                    tickRate = minTickRate;
                    return true;
                }
                break;
            default:
                return base.DoUpgrade(upgrade);
        }
        return false;
    }

}
