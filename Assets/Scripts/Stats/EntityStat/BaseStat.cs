using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StatUpgradeSO;

public class BaseStat : MonoBehaviour
{
    protected Stats.EntityStat stat;
    [SerializeField] protected float baseValue;

    public virtual bool DoUpgrade(StatIncrease statUpgrade)
    {
        baseValue += statUpgrade.value;
        return false;
    }

    public Stats.EntityStat GetStatType()
    {
        return stat;
    }

    public float GetStatValue()
    {
        return baseValue;
    }
}
