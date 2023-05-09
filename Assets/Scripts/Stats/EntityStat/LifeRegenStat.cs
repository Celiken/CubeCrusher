using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LifeStat))]
public class LifeRegenStat : BaseStat
{
    private LifeStat lifeController;

    private void Awake()
    {
        stat = Stats.EntityStat.LifeRegen;
    }

    private void Start()
    {
        lifeController = GetComponent<LifeStat>();
    }

    private void Update()
    {
        lifeController.Heal(baseValue * Time.deltaTime);
    }

    public override bool DoUpgrade(StatUpgradeSO.StatIncrease statUpgrade)
    {
        return base.DoUpgrade(statUpgrade);
    }
}
