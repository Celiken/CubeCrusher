using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : ScriptableObject
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

    public abstract bool DoUpgrade();
}
