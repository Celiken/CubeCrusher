using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class WeaponUpgradeSO : ScriptableObject
{
    public enum UpgradeType
    {
        Unlock,
        Upgrade
    }

    public UpgradeType upgradeType;
    public WeaponsManager.WeaponType weaponType;
    public Sprite upgradeIcon;
    public string upgradeName;
    public string description;

    [Serializable]
    public struct WeaponIncrease
    {
        public Stats.WeaponStat stat;
        public float value;
    }

    public WeaponIncrease upgradeToApply;

    public bool DoUpgrade()
    {
        return WeaponsManager.Instance.weaponDictionary[weaponType].DoUpgrade(upgradeToApply);
    }
}
