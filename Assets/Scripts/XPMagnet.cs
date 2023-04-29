using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPMagnet : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private float magnetPower;

    private SphereCollider magnetCollider;

    private void Awake()
    {
        magnetCollider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        magnetCollider.radius = magnetPower;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out XP xp))
        {
            player.AddXP(xp.GetAmount());
            Destroy(other.gameObject);
        }
    }
}
