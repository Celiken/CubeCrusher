using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StatUpgradeSO : ScriptableObject
{
    public Sprite upgradeIcon;
    public string upgradeName;
    public string description;

    [Serializable]
    public struct StatIncrease
    {
        public Stats.EntityStat stat;
        public float value;
    }

    public StatIncrease upgradeToApply;

    //public bool DoUpgrade()
    //{
    //    return StatsManager.Instance.statDictionary[upgradeToApply.stat].DoUpgrade(upgradeToApply);
    //}
}
