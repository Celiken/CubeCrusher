using DG.Tweening;
using UnityEngine;

public class EntityVisual : MonoBehaviour
{
    [SerializeField] private GameObject visualDamage;

    private Color baseColorDamage = new Color(1f, 1f, 1f, 1f);
    private Vector3 rotationAxisSpeed;

    private void Awake()
    {
        rotationAxisSpeed = new Vector3(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f));
    }

    private void Start()
    {
        visualDamage.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationAxisSpeed * Time.deltaTime);
    }

    public void ChangeColor(Stance.Type stance)
    {
        GetComponent<Renderer>().material.SetColor("_BaseColor", Stance.GetColor(stance));
        GetComponent<Renderer>().material.SetColor("_EmissionColor", Stance.GetColor(stance) * 2f);
    }

    public void GetHit()
    {
        visualDamage.GetComponent<Renderer>().material.color = baseColorDamage;
        visualDamage.GetComponent<Renderer>().material.DOFade(0f, .5f);
    }
}
