using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class StatUpgrade : Upgrade
{
    [Serializable]
    public struct Increase
    {
        public Stats.Stat stat;
        public float value;
    }

    public List<Increase> upgradeToApplyList = new List<Increase>();

    public override bool DoUpgrade()
    {
        return WeaponsManager.Instance.weaponDictionary[weaponType].DoUpgrade(this);
    }
}
