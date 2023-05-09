using UnityEngine;

public class MeleeWeaponBehaviour : MonoBehaviour
{
    protected Stance.Type color;
        
    public virtual void Init<T>(T ctrl, Stance.Type color, float lifetime)
    {
        this.color = color;
    }
}
