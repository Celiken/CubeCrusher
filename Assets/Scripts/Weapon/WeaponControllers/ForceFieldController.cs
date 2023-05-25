using UnityEngine;

public class ForceFieldController : WeaponController
{
    [Header("TickRate")]
    [SerializeField] public float TickRate;

    private Stance.Type currentField;
    private GameObject forceField;

    protected override void Start()
    {
        forceField = Instantiate(prefab, transform.position, Quaternion.identity, transform);
        ComputeValues();
        base.Start();
    }

    protected override void Attack()
    {
        Stance.Type newField;
        do
        {
            newField = Stance.GetRandomColor();
        } while (newField == currentField);
        currentField = newField;
        forceField.GetComponent<MeleeWeaponBehaviour>().Init(this, currentField, Cooldown);
        base.Attack();
    }

    public override void ComputeValues()
    {
        base.ComputeValues();
    }
}
