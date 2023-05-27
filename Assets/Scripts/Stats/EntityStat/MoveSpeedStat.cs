using UnityEngine;

public class MoveSpeedStat : BaseStat
{
    [SerializeField] private float mSpeed;

    public override bool DoUpgrade(StatUpgradeSO.StatIncrease statUpgrade)
    {
        base.DoUpgrade(statUpgrade);
        if (value >= mSpeed)
        {
            value = mSpeed;
            return true;
        }
        return false;
    }
}
