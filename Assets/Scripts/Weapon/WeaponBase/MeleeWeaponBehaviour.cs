using UnityEngine;

public class MeleeWeaponBehaviour : MonoBehaviour
{
    protected Stance.Type color;
        
    public virtual void Init<T>(T ctrl, Stance.Type color = Stance.Type.Undefined, float lifetime = 0f)
    {
        this.color = color;
    }
}
