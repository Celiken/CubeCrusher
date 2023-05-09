using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    public enum EntityStat
    {
        Life,
        LifeRegen,
        MoveSpeed,
        Armor,
        BaseDamage,
        CritRate,
        CritDamage,
    }

    public enum WeaponStat
    {
        Unlock,
        Damage,
        Range,
        Cooldown,
        TickRate,
        Pierce,
    }
}
