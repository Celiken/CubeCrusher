using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    protected Vector3 direction;
    protected ColorType.Color color;

    public virtual void Init<T>(T ctrl, Vector3 direction, float lifetime, ColorType.Color color)
    {
        this.color = color;
        this.direction = direction;
        Destroy(gameObject, lifetime);
    }
}
