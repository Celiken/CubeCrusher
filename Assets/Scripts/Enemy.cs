using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private GameObject visualGO;

    private GameInput gameInput;
    private Player playerTarget;

    private ColorType.Color color;

    void Start()
    {
        playerTarget = Player.Instance;
        gameInput = GameInput.Instance;
        color = ColorType.GetRandomColor();
        ChangeRender();
    }

    void Update()
    {
        Vector3 moveDir = (playerTarget.transform.position - transform.position).normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    private void ChangeRender()
    {
        visualGO.GetComponent<Renderer>().material = ColorType.GetMaterialForColor(color);
    }
}
