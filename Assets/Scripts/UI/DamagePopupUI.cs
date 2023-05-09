using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DamagePopupUI : MonoBehaviour
{
    public static DamagePopupUI Create(Vector3 position, int damageAmount, Stance.Type color, bool isCrit)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.Instance.pfDamagePopup, position, Quaternion.identity);
        DamagePopupUI damagePopup = damagePopupTransform.GetComponent<DamagePopupUI>();
        damagePopup.Setup(damageAmount, position, color, isCrit);
        return damagePopup;
    }

    private TextMeshPro textMesh;
    [SerializeField] private float animDuration = .5f;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    public void Setup(int damage, Vector3 position, Stance.Type color, bool isCrit)
    {
        textMesh.text = damage.ToString();
        textMesh.fontMaterial = Stance.GetDamageFont(isCrit);
        textMesh.colorGradient = Stance.GetColorGradientForTextUI(color, isCrit);
        textMesh.fontSize = isCrit ? textMesh.fontSize * 2 : textMesh.fontSize;
        float moveXOffset = Random.Range(-1f, 1f);
        float moveYOffset = Random.Range(0, 1f);
        float moveZOffset = Random.Range(-1f, 1f);
        textMesh.transform.DOMove(position + new Vector3(moveXOffset, moveYOffset, moveZOffset), animDuration);
        textMesh.DOFade(0f, animDuration).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}
