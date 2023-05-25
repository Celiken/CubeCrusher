using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RowUpgradeUI : MonoBehaviour
{
    private UpgradeSO.Type upgradeType;

    [SerializeField] private Image Icon;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Level;
    [SerializeField] private TextMeshProUGUI Description;

    private WeaponUpgradeSO weaponUpgradeRef = null;
    private StatUpgradeSO statUpgradeRef = null;

    public void Init(WeaponUpgradeSO upgrade)
    {
        upgradeType = UpgradeSO.Type.Weapon;
        weaponUpgradeRef = upgrade;
        Icon.sprite = upgrade.upgradeIcon;
        Name.text = upgrade.upgradeName;
        if (WeaponsManager.Instance.weaponDictionary[upgrade.weaponType].unlock)
            Level.text = "Lv." + WeaponsManager.Instance.weaponDictionary[upgrade.weaponType].GetWeaponLevel();
        else
            Level.text = "Unlock";
        Description.text = upgrade.description;
    }

    public void Init(StatUpgradeSO upgrade)
    {
        upgradeType = UpgradeSO.Type.Stat;
        statUpgradeRef = upgrade;
        Icon.sprite = upgrade.upgradeIcon;
        Name.text = upgrade.upgradeName;
        Level.text = "Lv." + Player.Instance.GetStats().statDictionary[upgrade.upgradeToApply.stat].GetStatLevel();
        Description.text = upgrade.description;
    }

    public void OnClick()
    {
        if (upgradeType == UpgradeSO.Type.Weapon)
        {
            if (weaponUpgradeRef.DoUpgrade())
                WeaponsManager.Instance.RemoveUpgrade(weaponUpgradeRef);
        }
        else if (statUpgradeRef.DoUpgrade())
            WeaponsManager.Instance.RemoveUpgrade(statUpgradeRef);
        UpgradeUI.Instance.EndUpgradeProcess();
    }
}
