using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class XP : MonoBehaviour
{
    private Player player;

    private int amount;
    private XPManager manager;

    [SerializeField] private float speed;

    private Tweener tweener;

    private void Awake()
    {
        player = Player.Instance;
    }

    void Start()
    {
        amount = 1;
        manager = XPManager.Instance;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if ((transform.position - player.transform.position).magnitude <= 0.1f)
        {
            player.AddXP(amount);
            Destroy(gameObject);
        }
    }

    public int GetAmount()
    {
        return amount;
    }
}
