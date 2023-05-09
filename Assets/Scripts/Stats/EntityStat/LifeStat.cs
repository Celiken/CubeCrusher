public class LifeStat : BaseStat
{
    private float currentLife;

    public override bool DoUpgrade(StatUpgradeSO.StatIncrease statUpgrade)
    {
        return base.DoUpgrade(statUpgrade);
    }

    public override void InitLevel(int level)
    {
        base.InitLevel(level);
        currentLife = value;
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
        if (currentLife >= value) currentLife = (int)value;
        return (int)currentLife;
    }

    public int GetHPRemaining()
    {
        return (int)currentLife;
    }
    public int GetMaxHP()
    {
        return (int)value;
    }
}
