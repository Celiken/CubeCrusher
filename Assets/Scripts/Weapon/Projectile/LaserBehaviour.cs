using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : ProjectileWeaponBehaviour
{
    [SerializeField] private GameObject mainProj;
    [SerializeField] private TrailRenderer trail;
    LaserController laserCtrl;

    // Start is called before the first frame update
    protected override void Start()
    {
        laserCtrl = FindObjectOfType<LaserController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += laserCtrl.speed * Time.deltaTime * direction;
    }

    private void OnDestroy()
    {
        trail.transform.parent = null;
        trail.autodestruct = true;
        trail = null;
    }

    public override void Init(Vector3 dir, float baseSpeed, ColorType.Color color)
    {
        base.Init(dir, baseSpeed, color);
        Material mat = GetColorMat(color);

        mainProj.GetComponent<Renderer>().material = mat;
        trail.material = mat;
    }

    private Material GetColorMat(ColorType.Color color)
    {
        switch (color)
        {
            default:
                return GameAssets.Instance.whiteProj;
            case ColorType.Color.Blue:
                return GameAssets.Instance.blueProj;
            case ColorType.Color.Red:
                return GameAssets.Instance.redProj;
            case ColorType.Color.Green:
                return GameAssets.Instance.greenProj;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (color == enemy.GetActualColor())
            {
                enemy.DestroySelf();
                Destroy(this);
            }
        }
    }
}
