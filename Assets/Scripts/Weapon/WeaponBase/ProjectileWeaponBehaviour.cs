using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    protected Vector3 direction;
    protected Stance.Type color;

    public virtual void Init<T>(T ctrl, Vector3 direction, float lifetime, Stance.Type color)
    {
        this.color = color;
        this.direction = direction;
        Destroy(gameObject, lifetime);
    }
}
