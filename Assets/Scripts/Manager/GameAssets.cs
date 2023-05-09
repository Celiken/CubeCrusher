using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [Header("Laser Mat")]
    public Material blueLaser;
    public Material greenLaser;
    public Material redLaser;

    [Header("ForceField Mat")]
    public Material blueField;
    public Material greenField;
    public Material redField;

    [Header("Damage UI Prefabs")]
    public Transform pfDamagePopup;

    [Header("Damage UI Fonts")]
    public Material damageFont;
    public Material critDamageFont;

    [Header("Damage UI Gradient")]
    public VertexGradient blueGradient;
    public VertexGradient greenGradient;
    public VertexGradient redGradient;

    [Header("Crit Damage UI Gradient")]
    public VertexGradient blueCritGradient;
    public VertexGradient greenCritGradient;
    public VertexGradient redCritGradient;
}
