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
        timerNextTick -= Time.deltaTime;
        if (timerNextTick <= 0f)
        {
            ClearListEntity();
            timerNextTick = controller.tickRate;
            Tick();
        }
        transform.localScale = new Vector3(controller.range, 5f, controller.range);
    }

    public override void Init<T>(T ctrl, Stance.Type color, float lifetime)
    {
        controller = ctrl as ForceFieldController;
        base.Init(ctrl, color, lifetime);

        timerNextTick = 0f;

        transform.localScale = new Vector3(controller.range, 5f, controller.range);

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
            if (!listEnemyOnField.Contains(enemy))
            {
                listEnemyOnField.Add(enemy);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (listEnemyOnField.Contains(enemy))
            {
                listEnemyOnField.Remove(enemy);
            }
        }
    }

    private void ClearListEntity()
    {
        listEnemyOnField.RemoveAll(x => x == null);
    }

    private void Tick()
    {
        foreach (var enemy in listEnemyOnField)
        {
            if (enemy != null && color == enemy.GetActualColor())
            {
                bool isCrit = Player.Instance.GetStats().GetStatComponent<CritRateStat>(Stats.EntityStat.CritRate).IsCrit();
                enemy.Hit(isCrit ? (controller.GetDamage() * Player.Instance.GetStats().GetStatComponent<CritDamageStat>(Stats.EntityStat.CritDamage).GetBaseValue()) : controller.GetDamage(), isCrit);
            }
        }
    }
}
