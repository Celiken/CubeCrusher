using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public static UpgradeUI Instance;

    private WeaponsManager weaponsManager;

    [SerializeField] private GameObject upgradePanel;

    [SerializeField] private Transform parent;
    [SerializeField] private GameObject prefab;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        weaponsManager = WeaponsManager.Instance;
        XPManager.Instance.OnLevelUp += XPManager_OnLevelUp;
        EndUpgradeProcess();
    }

    private void XPManager_OnLevelUp(object sender, System.EventArgs e)
    {
        StartUpgradeProcess();
    }

    public void StartUpgradeProcess()
    {
        Time.timeScale = 0f;
        upgradePanel.SetActive(true);
        var list = weaponsManager.GetRandomUpgrade(3);
        PopulateUpgradeList(list);
        SelectItemInList();
    }

    public void EndUpgradeProcess()
    {
        ClearUpgradeList();
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PopulateUpgradeList(List<WeaponUpgradeSO> upgradeList)
    {
        foreach (var upgrade in upgradeList)
        {
            GameObject row = Instantiate(prefab, parent);
            row.GetComponent<RowUpgradeUI>().Init(upgrade);
        }
    }

    public void SelectItemInList()
    {
        parent.GetChild(1).GetComponent<Button>().Select();
    }

    public void ClearUpgradeList()
    {
        foreach (Transform child in parent.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
