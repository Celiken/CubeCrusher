using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour
{
    private int amount;
    private XPManager manager;

    void Start()
    {
        amount = 1;
        manager = XPManager.Instance;
    }

    public int GetAmount()
    {
        return amount;
    }
}
