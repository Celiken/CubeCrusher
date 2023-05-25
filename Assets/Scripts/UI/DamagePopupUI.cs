using DG.Tweening;
using TMPro;
using UnityEngine;

public class DamagePopupUI : MonoBehaviour
{
    public static DamagePopupUI Create(Vector3 position, int damageAmount, Stance.Type color)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.Instance.pfDamagePopup, position, Quaternion.identity);
        DamagePopupUI damagePopup = damagePopupTransform.GetComponent<DamagePopupUI>();
        damagePopup.Setup(damageAmount, position, color);
        return damagePopup;
    }

    private TextMeshPro textMesh;
    [SerializeField] private float animDuration = .5f;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    public void Setup(int damage, Vector3 position, Stance.Type color)
    {
        textMesh.text = damage.ToString();
        textMesh.colorGradient = Stance.GetColorGradientForTextUI(color);
        textMesh.fontSize = textMesh.fontSize;
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
