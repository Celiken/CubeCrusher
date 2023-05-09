using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritDamageStat : BaseStat
{
    public override bool DoUpgrade(StatUpgradeSO.StatIncrease statUpgrade)
    {
        return base.DoUpgrade(statUpgrade);
    }

    private void Awake()
    {
        stat = Stats.EntityStat.CritDamage;
    }
}
