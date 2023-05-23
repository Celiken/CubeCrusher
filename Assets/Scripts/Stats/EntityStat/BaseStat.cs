using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat : MonoBehaviour
{
    [SerializeField] protected Stats.EntityStat stat;
    [SerializeField] protected float baseValue;
    [SerializeField] protected float statMultiplier;

    private int level = 0;

    protected float value;

    public virtual bool DoUpgrade(StatUpgradeSO.StatIncrease statUpgrade)
    {
        baseValue += statUpgrade.value;
        level++;
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

    public int GetIntBaseValue()
    {
        return Mathf.RoundToInt(baseValue);
    }

    public float GetLeveledValue()
    {
        return value;
    }

    public int GetIntLeveledValue()
    {
        return Mathf.RoundToInt(value);
    }

    public int GetStatLevel()
    {
        return level;
    }
}
