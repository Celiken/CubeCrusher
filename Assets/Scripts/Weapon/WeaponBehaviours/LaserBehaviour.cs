using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : ProjectileWeaponBehaviour
{
    [SerializeField] private GameObject mainProj;
    [SerializeField] private TrailRenderer trail;
    LaserController controller;

    private int targetPierced;

    void Update()
    {
        transform.position += controller.speed * Time.deltaTime * direction;
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
        Material mat = GetColorMat(color);
        if (mat == null)
            Debug.LogError($"Did not found a material for color {color}");
        else
        {
            mainProj.GetComponent<Renderer>().material = mat;
            trail.material = mat;
        }
    }

    private Material GetColorMat(Stance.Type color)
    {
        switch (color)
        {
            case Stance.Type.Blue:
                return GameAssets.Instance.blueLaser;
            case Stance.Type.Red:
                return GameAssets.Instance.redLaser;
            case Stance.Type.Green:
                return GameAssets.Instance.greenLaser;
        }
        return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (color == enemy.GetActualColor())
            {
                enemy.Hit(controller.damage);
                targetPierced++;
                if (targetPierced >= controller.pierce)
                    Destroy(this);
            }
        }
    }
}
