using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritRateStat : BaseStat
{
    public override bool DoUpgrade(StatUpgradeSO.StatIncrease statUpgrade)
    {
        return base.DoUpgrade(statUpgrade);
    }

    public bool IsCrit()
    {
        return Random.Range(0f, 1f) <= baseValue;
    }
}
