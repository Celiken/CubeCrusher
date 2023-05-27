using UnityEngine;

public class CooldownStat : BaseStat
{
    [SerializeField] protected float mCooldown;

    public override bool DoUpgrade(StatUpgradeSO.StatIncrease statUpgrade)
    {
        base.DoUpgrade(statUpgrade);
        if (value >= mCooldown)
        {
            value = mCooldown;
            return true;
        }
        return false;
    }
}
