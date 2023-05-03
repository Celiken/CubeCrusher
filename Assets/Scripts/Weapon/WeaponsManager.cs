using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private List<StatUpgrade> upgradesList;
    [SerializeField] private List<StatUpgrade> availableUpgrade;

    private void Awake()
    {
        Instance = this;
        weaponDictionary = new Dictionary<WeaponType, WeaponController>();
        foreach (var weapon in weapons)
        {
            weaponDictionary.Add(weapon.type, weapon);
        }
    }

    private void Start()
    {
        UpdateAvailableList();
    }

    public List<StatUpgrade> GetRandomUpgrade(int count)
    {
        var list = new List<StatUpgrade>();

        if (count > upgradesList.Count)
        {
            count = upgradesList.Count;
        }
        for (int i = 0; i < count; i++)
        {
            list.Add(availableUpgrade[Random.Range(0, availableUpgrade.Count)]);
        }

        return list;
    }

    public void RemoveUpgrade(StatUpgrade upgrade)
    {
        upgradesList.Remove(upgrade);
        UpdateAvailableList();
    }

    private void UpdateAvailableList()
    {
        availableUpgrade.Clear();
        foreach (var upgrade in upgradesList)
        {
            if (upgrade.upgradeType != Upgrade.UpgradeType.Unlock && weaponDictionary[upgrade.weaponType].unlock)
            {
                availableUpgrade.Add(upgrade);
            }
            else if (upgrade.upgradeType == Upgrade.UpgradeType.Unlock && !weaponDictionary[upgrade.weaponType].unlock)
            {
                availableUpgrade.Add(upgrade);
            }
        }
    }
}
