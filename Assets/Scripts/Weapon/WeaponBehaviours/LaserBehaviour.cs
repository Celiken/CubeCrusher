using UnityEngine;

public class LaserBehaviour : ProjectileWeaponBehaviour
{
    [SerializeField] private GameObject mainProj;
    [SerializeField] private TrailRenderer trail;
    LaserController controller;

    private int targetPierced;

    void Update()
    {
        transform.position += controller.Speed * Time.deltaTime * direction;
    }

    private void OnDestroy()
    {
        trail.transform.parent = null;
        trail.autodestruct = true;
        trail = null;
    }

    public override void Init<T>(T ctrl, Vector3 dir, float baseSpeed, Stance.Type color)
    {
        controller = ctrl as LaserController;
        base.Init(ctrl, dir, baseSpeed, color);
        targetPierced = 0;
        mainProj.GetComponent<Renderer>().material.SetColor("_BaseColor", Stance.GetColor(color));
        mainProj.GetComponent<Renderer>().material.SetColor("_EmissionColor", Stance.GetColor(color) * 2f);
        trail.material.SetColor("_BaseColor", Stance.GetColor(color));
        trail.material.SetColor("_EmissionColor", Stance.GetColor(color) * 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (color == enemy.GetActualColor())
            {
                enemy.Hit(controller.GetDamage());
                targetPierced++;
                if (targetPierced >= controller.Pierce)
                    Destroy(this);
            }
        }
    }
}
