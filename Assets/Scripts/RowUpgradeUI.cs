using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RowUpgradeUI : MonoBehaviour
{
    [SerializeField] private Image Icon;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Description;

    private WeaponStatUpgrade upgradeRef;

    public void Init(WeaponStatUpgrade upgrade)
    {
        upgradeRef = upgrade;
        Icon.sprite = upgrade.upgradeIcon;
        Name.text = upgrade.upgradeName;
        Description.text = upgrade.description;
    }

    public void OnClick()
    {
        bool maxed = upgradeRef.DoUpgrade();
        if (upgradeRef.upgradeType == WeaponUpgrade.UpgradeType.Unlock || maxed)
            WeaponsManager.Instance.RemoveUpgrade(upgradeRef);
        UpgradeUI.Instance.EndUpgradeProcess();
    }
}
