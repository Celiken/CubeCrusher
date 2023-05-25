using UnityEngine;

public class XP : MonoBehaviour
{
    private Player player;

    private int amount;

    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    private float speed;

    private void Awake()
    {
        player = Player.Instance;
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Start()
    {
        amount = 1;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if ((transform.position - player.transform.position).magnitude <= 0.1f)
        {
            player.AddXP(amount);
            DestroySelf();
        }
    }

    public void DestroySelf()
    {
        XPManager.Instance.QueueXPOrb(gameObject);
    }

    public int GetAmount()
    {
        return amount;
    }
}
