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

    [SerializeField] private List<UpgradeSO> upgradesList;
    private List<UpgradeSO> availableUpgrade;

    private void Awake()
    {
        Instance = this;
        weaponDictionary = new Dictionary<WeaponType, WeaponController>();
        availableUpgrade = new List<UpgradeSO>();
        foreach (var weapon in weapons)
        {
            weaponDictionary.Add(weapon.type, weapon);
        }
    }

    private void Start()
    {
        UpdateAvailableList();
    }

    public List<UpgradeSO> GetRandomUpgrade(int count)
    {
        UpdateAvailableList();
        var list = new List<UpgradeSO>();

        if (count > availableUpgrade.Count)
        {
            count = availableUpgrade.Count;
        }
        for (int i = 0; i < count; i++)
        {
            var tmp = availableUpgrade[Random.Range(0, availableUpgrade.Count)];
            list.Add(tmp);
            availableUpgrade.Remove(tmp);
        }

        return list;
    }

    public void UpdateWeaponsStats()
    {
        foreach (var weapon in weapons)
        {
            weapon.ComputeValues();
        }
    }

    public void RemoveUpgrade(UpgradeSO upgrade)
    {
        upgradesList.Remove(upgrade);
    }

    private void UpdateAvailableList()
    {
        availableUpgrade = new List<UpgradeSO>();
        foreach (var upgrade in upgradesList)
        {
            if (upgrade.requiredWeapon.Count == 0)
                availableUpgrade.Add(upgrade);
            else
            {
                foreach (var required in upgrade.requiredWeapon)
                {
                    if (weaponDictionary[required].unlock)
                    {
                        availableUpgrade.Add(upgrade);
                        break;
                    }
                }
            }
        }
    }
}
