using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] protected GameObject prefab;
    [SerializeField] protected float cooldown;
    [SerializeField] public float damage;
    [SerializeField] public float speed;
    [SerializeField] public int pierce;

    private float timeBeforeNextAttack;

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

    protected virtual void Attack()
    {
        timeBeforeNextAttack = cooldown;
    }
}
