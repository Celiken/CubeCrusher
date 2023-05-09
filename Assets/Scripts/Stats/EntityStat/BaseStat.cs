using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StatUpgradeSO;

public class BaseStat : MonoBehaviour
{
    [SerializeField] protected Stats.EntityStat stat;
    [SerializeField] protected float baseValue;
    [SerializeField] protected float statMultiplier;

    protected float value;

    public virtual bool DoUpgrade(StatIncrease statUpgrade)
    {
        baseValue += statUpgrade.value;
        return false;
    }

    public virtual void InitLevel(int level)
    {
        value = baseValue * Mathf.Pow(statMultiplier, level);
    }

    public Stats.EntityStat GetStatType()
    {
        return stat;
    }

    public float GetBaseValue()
    {
        return baseValue;
    }

    public float GetLeveledValue()
    {
        return value;
    }
}
