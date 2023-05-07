using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int maxHP;
    private int curHP;

    private void Awake()
    {
        curHP = maxHP;
    }

    public float TakeDamage(int damage)
    {
        curHP -= damage;
        return curHP;
    }

    public int GetHPRemaining()
    {
        return curHP;
    }
    public int GetMaxHP()
    {
        return maxHP;
    }
}
