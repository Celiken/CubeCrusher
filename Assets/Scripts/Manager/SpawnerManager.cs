using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public static SpawnerManager Instance;

    private EnemyTargeter targeter;

    [SerializeField] private Transform centerPoint;
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private float spawnRate;
    [SerializeField] private float absoluteSpawnAngle;
    [SerializeField] private int spawnPositionSwapRate;
    [SerializeField] private float spawnDistance = 50f;
    [SerializeField] private float spawnRateFactor = 1.4f;
    [SerializeField] private int maxEnemyAmount = 100;


    [SerializeField] private LayerMask spawnLayerMask;

    private Player player;

    private Vector3 lastSpawnDirection;

    private float nextSpawnTimer;
    private int nextSpawnPosRandomPicking;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTimer = 0;
        nextSpawnPosRandomPicking = 0;
        player = Player.Instance;
        targeter = GetComponent<EnemyTargeter>();
        lastSpawnDirection = PickRandomDirection();
    }

    // Update is called once per frame
    void Update()
    {
        nextSpawnTimer -= Time.deltaTime;
        if (nextSpawnTimer <= 0f && targeter.GetEnemiesSpawnedAmount() < maxEnemyAmount)
        {
            nextSpawnTimer = 1f / spawnRate;
            SpawnEnemy();
            nextSpawnPosRandomPicking++;
        }
    }

    public void IncreaseSpawnRate()
    {
        if (spawnRate < 50f)
            spawnRate *= spawnRateFactor;
    }

    public void SpawnEnemy()
    {
        if (nextSpawnPosRandomPicking >= spawnPositionSwapRate)
        {
            nextSpawnPosRandomPicking = 0;
            lastSpawnDirection = PickNewSpawnDirection();
        }

        int safetyNet = 50;
        int offset;
        for (offset = 0; offset < safetyNet; offset++)
        {
            if (PreventSpawnLocationOverlap(offset))
                break;
        }
        if (offset < safetyNet)
        {
            GameObject enemyGO = Instantiate(enemyPrefab, player.transform.position + (lastSpawnDirection * (spawnDistance + offset)), Quaternion.identity, centerPoint);
            lastSpawnDirection = Quaternion.AngleAxis((Random.value < 0.5f ? -1 : 1) * absoluteSpawnAngle, Vector3.up) * lastSpawnDirection;
        }
    }

    private bool PreventSpawnLocationOverlap(int offset)
    {
        Vector3 finalPos = player.transform.position + (lastSpawnDirection * (spawnDistance + offset));
        Collider[] collider = new Collider[1];
        int nbOverlap = Physics.OverlapSphereNonAlloc(finalPos, 2f, collider, spawnLayerMask);
        return nbOverlap == 0;
    }

    public Vector3 PickRandomDirection()
    {
        Vector3 rnd;
        do
        {
            rnd = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
        } while (rnd == Vector3.zero);
        return rnd;
    }

    public Vector3 PickNewSpawnDirection()
    {
        Vector3 playerDir = player.GetLastMoveDir();
        if (playerDir == Vector3.zero)
            return PickRandomDirection();
        return playerDir;
    }
}
