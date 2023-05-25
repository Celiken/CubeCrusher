using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeter : MonoBehaviour
{
    public static EnemyTargeter Instance;


    private List<Enemy> redEnemyList = new List<Enemy>();
    private List<Enemy> blueEnemyList = new List<Enemy>();
    private List<Enemy> greenEnemyList = new List<Enemy>();
    private Player player;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        player = Player.Instance;
    }

    public int GetEnemiesSpawnedAmount()
    {
        return redEnemyList.Count + blueEnemyList.Count + greenEnemyList.Count;
    }

    public void AddEnemy(Enemy enemy)
    {
        switch (enemy.GetActualColor())
        {
            case Stance.Type.Blue:
                blueEnemyList.Add(enemy);
                break;
            case Stance.Type.Red:
                redEnemyList.Add(enemy);
                break;
            case Stance.Type.Green:
                greenEnemyList.Add(enemy);
                break;
        }
    }

    public void RemoveEnemy(Enemy enemy)
    {
        switch (enemy.GetActualColor())
        {
            case Stance.Type.Blue:
                blueEnemyList.RemoveAll(x => x == enemy);
                break;
            case Stance.Type.Red:
                redEnemyList.RemoveAll(x => x == enemy);
                break;
            case Stance.Type.Green:
                greenEnemyList.RemoveAll(x => x == enemy);
                break;
        }
    }

    public List<Enemy> GetClosestEnemies(Stance.Type color, int amount)
    {
        switch (color)
        {
            case Stance.Type.Blue:
                return FindCloseEnemy(blueEnemyList, amount);
            case Stance.Type.Red:
                return FindCloseEnemy(redEnemyList, amount);
            case Stance.Type.Green:
                return FindCloseEnemy(greenEnemyList, amount);
        }
        return null;
    }

    public List<Enemy> FindCloseEnemy(List<Enemy> targets, int amount)
    {
        List<Enemy> res = new List<Enemy>();
        Vector3 playerPos = player.transform.position;
        if (amount > targets.Count) amount = targets.Count;
        while (res.Count < amount)
        {
            float nearDist = float.MaxValue;
            Enemy nearest = null;
            float enemyDist = 0f;
            foreach (var enemy in targets)
            {
                enemyDist = (enemy.transform.position - playerPos).sqrMagnitude;
                if (enemyDist <= nearDist && !res.Contains(enemy))
                {
                    nearDist = enemyDist;
                    nearest = enemy;
                }
            }
            if (nearest != null)
                res.Add(nearest);
        }
        return res;
    }
}
