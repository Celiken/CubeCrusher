using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class WeaponStatUpgrade : WeaponUpgrade
{
    [Serializable]
    public struct WeaponIncrease
    {
        public Stats.WeaoponStat stat;
        public float value;
    }

    public List<WeaponIncrease> upgradeToApplyList = new List<WeaponIncrease>();

    public override bool DoUpgrade()
    {
        return WeaponsManager.Instance.weaponDictionary[weaponType].DoUpgrade(this);
    }
}
