using UnityEngine;

public class RangeStat : BaseStat
{
    [SerializeField] protected float mRange;

    public override bool DoUpgrade(StatUpgradeSO.StatIncrease statUpgrade)
    {
        base.DoUpgrade(statUpgrade);
        if (value >= mRange)
        {
            value = mRange;
            return true;
        }
        return false;
    }
}
