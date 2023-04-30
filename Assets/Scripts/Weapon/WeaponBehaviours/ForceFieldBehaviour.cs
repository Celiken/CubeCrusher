using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldBehaviour : MeleeWeaponBehaviour
{
    [SerializeField] private GameObject mainProj;

    ForceFieldController controller;

    public override void Init<T>(T ctrl, ColorType.Color color, float lifetime)
    {
        controller = ctrl as ForceFieldController;
        base.Init(ctrl, color, lifetime);

        transform.localScale = new Vector3(controller.range, controller.range, controller.range);

        Material mat = GetColorMat(color);
        if (mat == null)
            Debug.LogError($"Did not found a material for color {color}");
        else
            mainProj.GetComponent<Renderer>().material = mat;

    }

    private Material GetColorMat(ColorType.Color color)
    {
        switch (color)
        {
            case ColorType.Color.Blue:
                return GameAssets.Instance.blueField ;
            case ColorType.Color.Red:
                return GameAssets.Instance.redField;
            case ColorType.Color.Green:
                return GameAssets.Instance.greenField;
            case ColorType.Color.Yellow:
                return GameAssets.Instance.yellowField;
        }
        return null;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (color == enemy.GetActualColor())
            {
                enemy.Hit(controller.damage * Time.deltaTime);
            }
        }
    }
}
