using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets Instance;

    private void Awake()
    {
        Instance = this;
    }

    [Header("Color Mat")]
    public Material blueMat;
    public Material redMat;
    public Material greenMat;

    [Header("XP")]
    public GameObject xpPrefab;

    [Header("Laser mat")]
    public Material blueLaser;
    public Material redLaser;
    public Material greenLaser;

    [Header("ForceField mat")]
    public Material blueField;
    public Material redField;
    public Material greenField;

    [Header("Damage UI prefabs")]
    public Transform pfDamagePopup;
}
