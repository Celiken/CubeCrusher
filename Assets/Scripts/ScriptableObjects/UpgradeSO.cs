using System.Collections;
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
    public Sprite upgradeIcon;
    public string upgradeName;
    public string description;
}
