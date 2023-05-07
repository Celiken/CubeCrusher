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

    [Header("Enemy Mat")]
    public Material blueEnemyMat;
    public Material greenEnemyMat;
    public Material redEnemyMat;

    [Header("Player Mat")]
    public Material bluePlayerMat;
    public Material greenPlayerMat;
    public Material redPlayerMat;

    [Header("XP")]
    public GameObject xpPrefab;

    [Header("Laser mat")]
    public Material blueLaser;
    public Material greenLaser;
    public Material redLaser;

    [Header("ForceField mat")]
    public Material blueField;
    public Material greenField;
    public Material redField;

    [Header("Damage UI prefabs")]
    public Transform pfDamagePopup;
}
