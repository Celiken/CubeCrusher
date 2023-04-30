using System.Collections.Generic;
using UnityEngine;

public class XPManager : MonoBehaviour
{

    public static XPManager Instance;

    [Header("Settings Level")]
    [SerializeField] private float baseXp;
    [SerializeField] private float xpMultiplier;

    [Header("Settings Pool XP Orbs")]
    [SerializeField] private int maxXpOrbs;
    Queue<GameObject> xpOrbsQueue = new Queue<GameObject>();

    [Header("Settings Pop XP Orbs")]
    [SerializeField] private float xpSpread;

    private int level;
    private int currentXP;
    private int requiredXP;

    private void Awake()
    {
        Instance = this;
        level = 1;
        currentXP = 0;
        UpdateXPRequired();
    }

    private void Start()
    {
        PrepareXpOrbs();
    }

    private void PrepareXpOrbs()
    {
        GameObject xpOrb;
        for (int i = 0; i < maxXpOrbs; i++)
        {
            xpOrb = Instantiate(GameAssets.Instance.xpPrefab, transform);
            xpOrb.SetActive(false);
            xpOrbsQueue.Enqueue(xpOrb);
        }
    }

    private void SpawnAdditionnalXpOrb(Transform targetTransform)
    {
        GameObject xpOrb;
        xpOrb = Instantiate(GameAssets.Instance.xpPrefab, transform);
        xpOrb.transform.position = targetTransform.position + new Vector3(Random.Range(-xpSpread, xpSpread), -.5f, Random.Range(-xpSpread, xpSpread));
        xpOrb.SetActive(true);
    }

    public void QueueXPOrb(GameObject xpOrb)
    {
        xpOrb.SetActive(false);
        xpOrbsQueue.Enqueue(xpOrb);
    }

    public void SpawnXP(Transform targetTransform, int xpAmount)
    {
        for (int i = 0; i < xpAmount; i++)
        {
            if (xpOrbsQueue.Count > 0)
            {
                GameObject xpOrb = xpOrbsQueue.Dequeue();
                xpOrb.transform.position = targetTransform.position + new Vector3(Random.Range(-xpSpread, xpSpread), -.5f, Random.Range(-xpSpread, xpSpread));
                xpOrb.SetActive(true);
            }
            else
                SpawnAdditionnalXpOrb(targetTransform);
        }
    }

    public void AddXP(int amount)
    {
        currentXP += amount;
        if (currentXP >= requiredXP)
            LevelUp();
    }

    private void LevelUp()
    {
        level++;
        currentXP -= requiredXP;
        UpdateXPRequired();
    }

    private void UpdateXPRequired()
    {
        requiredXP = Mathf.RoundToInt(Mathf.Pow(level / baseXp, xpMultiplier));
    }

    public int GetLevel()
    {
        return level;
    } 
    public int GetCurrentXP()
    {
        return currentXP;
    }
    public int GetRequiredXP()
    {
        return requiredXP;
    }
}
