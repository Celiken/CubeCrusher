using TMPro;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets Instance;

    private void Awake()
    {
        Instance = this;
    }

    [Header("XP")]
    public GameObject xpPrefab;

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
