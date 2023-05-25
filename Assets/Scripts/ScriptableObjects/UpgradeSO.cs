using System.Collections.Generic;
using UnityEngine;

public class UpgradeSO : ScriptableObject
{
    public enum Type
    {
        Weapon,
        Stat,
    }

    public Type type;
    public List<WeaponsManager.WeaponType> requiredWeapon;
    public Sprite upgradeIcon;
    public string upgradeName;
    public string description;
}
