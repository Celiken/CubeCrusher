using UnityEngine;

public class ForceFieldController : WeaponController
{
    [SerializeField] protected float lifetime;
    [SerializeField] public float tick;
    [SerializeField] public float range;
    [SerializeField] private Player player;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        Stance.Type color = Stance.GetRandomColor();
        GameObject field = Instantiate(prefab, transform.position, Quaternion.identity, transform);
        field.GetComponent<MeleeWeaponBehaviour>().Init(this, color, lifetime);
    }
}
