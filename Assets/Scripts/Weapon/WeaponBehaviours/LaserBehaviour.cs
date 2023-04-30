using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : ProjectileWeaponBehaviour
{
    [SerializeField] private GameObject mainProj;
    [SerializeField] private TrailRenderer trail;
    LaserController controller;

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

    public override void Init<T>(T ctrl, Vector3 dir, float baseSpeed, ColorType.Color color)
    {
        controller = ctrl as LaserController;
        base.Init(ctrl, dir, baseSpeed, color);

        Material mat = GetColorMat(color);
        if (mat == null)
            Debug.LogError($"Did not found a material for color {color}");
        else
        {
            mainProj.GetComponent<Renderer>().material = mat;
            trail.material = mat;
        }
    }

    private Material GetColorMat(ColorType.Color color)
    {
        switch (color)
        {
            case ColorType.Color.Blue:
                return GameAssets.Instance.blueLaser;
            case ColorType.Color.Red:
                return GameAssets.Instance.redLaser;
            case ColorType.Color.Green:
                return GameAssets.Instance.greenLaser;
            case ColorType.Color.Yellow:
                return GameAssets.Instance.yellowLaser;
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
                Destroy(this);
            }
        }
    }
}
