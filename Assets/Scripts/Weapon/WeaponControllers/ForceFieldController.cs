using UnityEngine;

public class ForceFieldController : WeaponController
{
    [Header("TickRate")]
    [SerializeField] protected float minTickRate;
    [SerializeField] public float tickRate;

    private Stance.Type currentField;
    private GameObject forceField;

    protected override void Start()
    {
        forceField = Instantiate(prefab, transform.position, Quaternion.identity, transform);
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        Stance.Type newField;
        do
        {
            newField = Stance.GetRandomColor();
        } while (newField == currentField);
        currentField = newField;
        forceField.GetComponent<MeleeWeaponBehaviour>().Init(this, currentField, cooldown);
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
