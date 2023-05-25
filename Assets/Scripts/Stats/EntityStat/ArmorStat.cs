using UnityEngine;

public class ArmorStat : BaseStat
{
    [SerializeField] protected float mArmor;

    public override bool DoUpgrade(StatUpgradeSO.StatIncrease statUpgrade)
    {
        base.DoUpgrade(statUpgrade);
        if (baseValue >= mArmor)
        {
            baseValue = mArmor;
            return true;
        }
        return false;
    }
}
