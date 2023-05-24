using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class AmountStat : BaseStat
{
    [SerializeField] protected float mAmount;

    public override bool DoUpgrade(StatUpgradeSO.StatIncrease statUpgrade)
    {
        base.DoUpgrade(statUpgrade);
        if (baseValue >= mAmount)
        {
            baseValue = mAmount;
            return true;
        }
        return false;
    }
}
