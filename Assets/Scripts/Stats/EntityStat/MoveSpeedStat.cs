public class MoveSpeedStat : BaseStat
{
    public override bool DoUpgrade(StatUpgradeSO.StatIncrease statUpgrade)
    {
        return base.DoUpgrade(statUpgrade);
    }

    private void Awake()
    {
        stat = Stats.EntityStat.MoveSpeed;
    }
}
