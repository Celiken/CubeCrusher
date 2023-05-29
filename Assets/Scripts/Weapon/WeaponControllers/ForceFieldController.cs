using UnityEngine;

public class ForceFieldController : WeaponController
{
    [Header("TickRate")]
    [SerializeField] public float TickRate;

    private GameObject forceField;

    protected override void Start()
    {
        forceField = Instantiate(prefab, transform.position, Quaternion.identity, transform);
        forceField.GetComponent<MeleeWeaponBehaviour>().Init(this);
        ComputeValues();
        base.Start();
    }

    public override void ComputeValues()
    {
        base.ComputeValues();
    }
}
