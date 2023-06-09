using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XPUI : MonoBehaviour
{
    private XPManager xpManager;

    [Header("UI Level")]
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Image xpBar;

    void Start()
    {
        xpManager = XPManager.Instance;
    }

    private void Update()
    {
        xpBar.fillAmount = (float)xpManager.GetCurrentXP() / xpManager.GetRequiredXP();
        levelText.text = $"Lv {xpManager.GetLevel()}";
    }
}
