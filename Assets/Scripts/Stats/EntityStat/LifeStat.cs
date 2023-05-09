public class LifeStat : BaseStat
{
    private float currentLife;

    public override bool DoUpgrade(StatUpgradeSO.StatIncrease statUpgrade)
    {
        return base.DoUpgrade(statUpgrade);
    }

    private void Awake()
    {
        stat = Stats.EntityStat.Life;
        currentLife = (int)baseValue;
    }

    public int TakeDamage(float damage)
    {
        currentLife -= damage;
        if (currentLife < 0) currentLife = 0;
        return (int)currentLife;
    }

    public int Heal(float heal)
    {
        currentLife += heal;
        if (currentLife >= baseValue) currentLife = (int)baseValue;
        return (int)currentLife;
    }

    public int GetHPRemaining()
    {
        return (int)currentLife;
    }
    public int GetMaxHP()
    {
        return (int)baseValue;
    }
}
