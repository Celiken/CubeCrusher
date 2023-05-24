using UnityEngine;

public class CooldownStat : BaseStat
{
    [SerializeField] protected float mCooldown;

    public override bool DoUpgrade(StatUpgradeSO.StatIncrease statUpgrade)
    {
        base.DoUpgrade(statUpgrade);
        if (baseValue >= mCooldown)
        {
            baseValue = mCooldown;
            return true;
        }
        return false;
    }
}
