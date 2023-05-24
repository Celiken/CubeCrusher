using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class WeaponUpgradeSO : UpgradeSO
{
    public WeaponsManager.WeaponType weaponType;

    public bool DoUpgrade()
    {
        return WeaponsManager.Instance.weaponDictionary[weaponType].DoUpgrade();
    }
}
