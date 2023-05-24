using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

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
            timerNextTick = controller.TickRate;
            Tick();
        }
        transform.localScale = new Vector3(controller.Range, 5f, controller.Range);
    }

    public override void Init<T>(T ctrl, Stance.Type color, float lifetime)
    {
        controller = ctrl as ForceFieldController;
        base.Init(ctrl, color, lifetime);

        timerNextTick = 0f;

        transform.localScale = new Vector3(controller.Range, 5f, controller.Range);

        mainProj.GetComponent<Renderer>().material.SetColor("_Emission", Stance.GetColor(color) * 2f);
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
                enemy.Hit(controller.GetDamage());
            }
        }
    }
}
