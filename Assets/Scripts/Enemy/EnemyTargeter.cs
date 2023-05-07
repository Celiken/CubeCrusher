using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeter : MonoBehaviour
{
    public static EnemyTargeter Instance;

    private KdTree<Enemy> redEnemyList = new KdTree<Enemy>();
    private KdTree<Enemy> blueEnemyList = new KdTree<Enemy>();
    private KdTree<Enemy> greenEnemyList = new KdTree<Enemy>();
    private Player player;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = Player.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        redEnemyList.UpdatePositions();
        blueEnemyList.UpdatePositions();
        greenEnemyList.UpdatePositions();
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

    public Enemy GetClosestEnemy(Stance.Type color)
    {
        switch (color)
        {
            case Stance.Type.Blue:
                return blueEnemyList.FindClosest(player.transform.position);
            case Stance.Type.Red:
                return redEnemyList.FindClosest(player.transform.position);
            case Stance.Type.Green:
                return greenEnemyList.FindClosest(player.transform.position);
        }
        return null;
    }
}
