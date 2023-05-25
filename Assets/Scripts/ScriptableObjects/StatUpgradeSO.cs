using System;
using UnityEngine;

[CreateAssetMenu]
public class StatUpgradeSO : UpgradeSO
{
    [Serializable]
    public struct StatIncrease
    {
        public Stats.EntityStat stat;
        public float value;
    }

    public StatIncrease upgradeToApply;

    public bool DoUpgrade()
    {
        return Player.Instance.GetStats().statDictionary[upgradeToApply.stat].DoUpgrade(upgradeToApply);
    }
}
