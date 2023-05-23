using UnityEngine;

public class RangeStat : BaseStat
{
    [SerializeField] protected float mRange;

    public override bool DoUpgrade(StatUpgradeSO.StatIncrease statUpgrade)
    {
        base.DoUpgrade(statUpgrade);
        if (baseValue >= mRange)
        {
            baseValue = mRange;
            return true;
        }
        return false;
    }
}
