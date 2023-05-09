using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponsManager : MonoBehaviour
{
    public static WeaponsManager Instance;

    public enum WeaponType
    {
        Laser,
        ForceField,
    }

    [SerializeField] private List<WeaponController> weapons;
    public Dictionary<WeaponType, WeaponController> weaponDictionary;

    [SerializeField] private List<WeaponUpgradeSO> upgradesList;
    private List<WeaponUpgradeSO> availableUpgrade;

    private void Awake()
    {
        Instance = this;
        weaponDictionary = new Dictionary<WeaponType, WeaponController>();
        availableUpgrade = new List<WeaponUpgradeSO>();
        foreach (var weapon in weapons)
        {
            weaponDictionary.Add(weapon.type, weapon);
        }
    }

    private void Start()
    {
        UpdateAvailableList();
    }

    public List<WeaponUpgradeSO> GetRandomUpgrade(int count)
    {
        UpdateAvailableList();
        var list = new List<WeaponUpgradeSO>();

        if (count > upgradesList.Count)
        {
            count = upgradesList.Count;
        }
        for (int i = 0; i < count; i++)
        {
            var tmp = availableUpgrade[Random.Range(0, availableUpgrade.Count)];
            list.Add(tmp);
            availableUpgrade.Remove(tmp);
        }

        return list;
    }

    public void RemoveUpgrade(WeaponUpgradeSO upgrade)
    {
        upgradesList.Remove(upgrade);
    }

    private void UpdateAvailableList()
    {
        availableUpgrade.Clear();
        foreach (var upgrade in upgradesList)
        {
            if (upgrade.upgradeType != WeaponUpgradeSO.UpgradeType.Unlock && weaponDictionary[upgrade.weaponType].unlock)
            {
                availableUpgrade.Add(upgrade);
            }
            else if (upgrade.upgradeType == WeaponUpgradeSO.UpgradeType.Unlock && !weaponDictionary[upgrade.weaponType].unlock)
            {
                availableUpgrade.Add(upgrade);
            }
        }
    }
}