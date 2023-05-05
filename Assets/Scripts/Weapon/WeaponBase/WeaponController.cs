using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] public WeaponsManager.WeaponType type;
    [SerializeField] public bool unlock;

    [Header("Weapon Stats")]
    [SerializeField] protected GameObject prefab;
    [SerializeField] protected float minCooldown;
    [SerializeField] protected float cooldown;
    [SerializeField] public float range;
    [SerializeField] public float speed;
    [SerializeField] public int damage;

    private float timeBeforeNextAttack;

    private void Awake()
    {
        gameObject.SetActive(unlock);
    }

    protected virtual void Start()
    {
        timeBeforeNextAttack = 0f;
    }

    protected virtual void Update()
    {
        timeBeforeNextAttack -= Time.deltaTime;
        if (timeBeforeNextAttack <= 0f)
        {
            timeBeforeNextAttack = 0f;
            Attack();
        }
    }

    protected virtual void Unlock()
    {
        unlock = true;
        gameObject.SetActive(unlock);
        timeBeforeNextAttack = 0f;
    }

    protected virtual void Attack()
    {
        timeBeforeNextAttack = cooldown;
    }

    public virtual bool DoUpgrade(StatUpgrade statUp)
    {
        Debug.LogError("WeaponController.DoUpgrade() shhould never be called");
        return false;
    }
}
