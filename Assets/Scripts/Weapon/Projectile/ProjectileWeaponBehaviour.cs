using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    [SerializeField] private float distance;
    protected Vector3 direction;
    protected ColorType.Color color;

    protected virtual void Start()
    {
    }

    public virtual void Init(Vector3 direction, float baseSpeed, ColorType.Color color)
    {
        this.color = color;
        this.direction = direction;
        Destroy(gameObject, distance / baseSpeed);
    }
}
