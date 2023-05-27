using UnityEngine;

public class AmountStat : BaseStat
{
    [SerializeField] protected float mAmount;

    public override bool DoUpgrade(StatUpgradeSO.StatIncrease statUpgrade)
    {
        base.DoUpgrade(statUpgrade);
        if (value >= mAmount)
        {
            value = mAmount;
            return true;
        }
        return false;
    }
}
