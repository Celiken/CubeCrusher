using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class XPManager : MonoBehaviour
{

    public static XPManager Instance;

    [Header("Settings Level")]
    [SerializeField] private int xpPerLevel;
    [SerializeField] private float xpMultiplier;

    [Header("UI Level")]
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Image xpBar;

    private int level;
    private int currentXp;
    private int xpRequired;

    private void Awake()
    {
        Instance = this;
        level = 1;
        currentXp = 0;
        UpdateXPRequired();
    }

    private void Update()
    {
        xpBar.fillAmount = (float)currentXp / xpRequired;
        levelText.text = $"Lvl {level}";
    }

    public void AddXP(int amount)
    {
        currentXp += amount;
        if (currentXp >= xpRequired)
            LevelUp();
    }

    private void LevelUp()
    {
        level++;
        currentXp -= xpRequired;
        UpdateXPRequired();
    }

    private void UpdateXPRequired()
    {
        xpRequired = Mathf.RoundToInt(level * xpPerLevel * xpMultiplier);
    }
}
