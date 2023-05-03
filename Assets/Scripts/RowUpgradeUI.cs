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

    private StatUpgrade upgradeRef;

    public void Init(StatUpgrade upgrade)
    {
        upgradeRef = upgrade;
        Icon.sprite = upgrade.icon;
        Name.text = upgrade.name;
        Description.text = upgrade.description;
    }

    public void OnClick()
    {
        upgradeRef.DoUpgrade();
        WeaponsManager.Instance.RemoveUpgrade(upgradeRef);
        UpgradeUI.Instance.EndUpgradeProcess();
    }
}
