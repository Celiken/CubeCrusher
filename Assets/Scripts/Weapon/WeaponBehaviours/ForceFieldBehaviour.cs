using System.Collections.Generic;
using UnityEngine;

public class ForceFieldBehaviour : MeleeWeaponBehaviour
{
    [SerializeField] private GameObject mainProj;

    private List<Enemy> listEnemyOnField = new List<Enemy>();

    private float timerNextTick;
    ForceFieldController controller;

    private void Update()
    {
        timerNextTick += Time.deltaTime;
        if (timerNextTick >= controller.tick)
        {
            timerNextTick -= controller.tick;
            Tick();
        }
    }

    public override void Init<T>(T ctrl, Stance.Type color, float lifetime)
    {
        controller = ctrl as ForceFieldController;
        base.Init(ctrl, color, lifetime);

        timerNextTick = 0f;

        transform.localScale = new Vector3(controller.range, controller.range, controller.range);

        Material mat = GetColorMat(color);
        if (mat == null)
            Debug.LogError($"Did not found a material for color {color}");
        else
            mainProj.GetComponent<Renderer>().material = mat;
    }

    private Material GetColorMat(Stance.Type color)
    {
        switch (color)
        {
            case Stance.Type.Blue:
                return GameAssets.Instance.blueField;
            case Stance.Type.Red:
                return GameAssets.Instance.redField;
            case Stance.Type.Green:
                return GameAssets.Instance.greenField;
        }
        return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (color == enemy.GetActualColor() && !listEnemyOnField.Contains(enemy))
            {
                listEnemyOnField.Add(enemy);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (color == enemy.GetActualColor() && listEnemyOnField.Contains(enemy))
            {
                listEnemyOnField.Remove(enemy);
            }
        }
    }

    private void Tick()
    {
        foreach (var enemy in listEnemyOnField)
        {
            if (enemy != null)
                enemy.Hit(controller.damage);
        }
    }
}
