using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField] private List<BaseStat> statsList;
    public Dictionary<Stats.EntityStat, BaseStat> statDictionary;

    private void Awake()
    {
        statDictionary = new Dictionary<Stats.EntityStat, BaseStat>();
        foreach (var statController in statsList)
        {
            statDictionary.Add(statController.GetStatType(), statController);
        }
    }

    public T GetStatComponent<T>(Stats.EntityStat stat) where T : BaseStat
    {
        return statDictionary[stat] as T;
    }

    public void InitLevel(int level)
    {
        foreach (var statController in statDictionary)
        {
            statController.Value.InitLevel(level);
        }
    }
}
