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

    [Header("Proj mat")]
    public Material whiteProj;
    public Material blueProj;
    public Material redProj;
    public Material greenProj;
}
