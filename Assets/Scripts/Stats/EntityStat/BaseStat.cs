using UnityEngine;

public class BaseStat : MonoBehaviour
{
    [SerializeField] protected Stats.EntityStat stat;
    [SerializeField] protected float baseValue;
    [SerializeField] protected float statMultiplier;

    [SerializeField] private int level = 0;
    [SerializeField] protected float value;
    [SerializeField] private bool hasMaxValue;
    [SerializeField] private float maxValue;

    public virtual bool DoUpgrade(StatUpgradeSO.StatIncrease statUpgrade)
    {
        level++;
        value += statUpgrade.value;
        if (hasMaxValue && value >= maxValue)
        {
            value = maxValue;
            return true;
        }
        return false;
    }

    public virtual void InitLevel(int level)
    {
        value = baseValue * Mathf.Pow(statMultiplier, level);
        if (hasMaxValue && value >= maxValue)
            value = maxValue;
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
