using UnityEngine;

public class MeleeWeaponBehaviour : MonoBehaviour
{
    protected ColorType.Color color;

    public virtual void Init<T>(T ctrl, ColorType.Color color, float lifetime)
    {
        this.color = color;
        Destroy(gameObject, lifetime);
    }
}
