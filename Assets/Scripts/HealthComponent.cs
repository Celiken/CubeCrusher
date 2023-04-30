using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float maxHP;
    private float curHP;

    private void Awake()
    {
        curHP = maxHP;
    }

    public float TakeDamage(float damage)
    {
        curHP -= damage;
        return curHP;
    }
}
