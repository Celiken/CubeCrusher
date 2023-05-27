using UnityEngine;

public class ArmorStat : BaseStat
{
    [SerializeField] protected float mArmor;

    public override bool DoUpgrade(StatUpgradeSO.StatIncrease statUpgrade)
    {
        base.DoUpgrade(statUpgrade);
        if (value >= mArmor)
        {
            value = mArmor;
            return true;
        }
        return false;
    }
}
