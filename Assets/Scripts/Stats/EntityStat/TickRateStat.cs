using System;
using UnityEngine;

public class TickRateStat : BaseStat
{
    [SerializeField] protected float mTickRate;

    public override bool DoUpgrade(StatUpgradeSO.StatIncrease statUpgrade)
    {
        base.DoUpgrade(statUpgrade);
        if (baseValue >= mTickRate)
        {
            baseValue = mTickRate;
            return true;
        }
        return false;
    }
}
