using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritRateStat : BaseStat
{
    public override bool DoUpgrade(StatUpgradeSO.StatIncrease statUpgrade)
    {
        return base.DoUpgrade(statUpgrade);
    }

    private void Awake()
    {
        stat = Stats.EntityStat.CritRate;
    }

    public bool IsCrit()
    {
        return Random.Range(0f, 1f) <= baseValue;
    }
}
