using UnityEngine;

public class FollowUV : MonoBehaviour
{
    [SerializeField] private float OverallScale;
    [SerializeField] private Color Tint;
    [SerializeField] private float MinClipThreshold;
    [SerializeField] private float MaxClipThreshold;
    [SerializeField] private float SpeedClipThreshold;
    [SerializeField] private float StarsScale;
    [SerializeField] private float Randomness;
    [SerializeField] private float BrightnessVariationScale;
    [SerializeField] private float BrightnessPower;
    [SerializeField] private float Brightness;


    [SerializeField] private float parralax = 1;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float val = Mathf.SmoothStep(MinClipThreshold, MaxClipThreshold, Mathf.PingPong(Time.time * SpeedClipThreshold, 1));
        sr.material.SetColor("_Tint", Tint);
        sr.material.SetFloat("_OverallScale", OverallScale);
        sr.material.SetFloat("_ClipThreshold", val);
        sr.material.SetFloat("_StarsScale", StarsScale);
        sr.material.SetFloat("_Randomness", Randomness);
        sr.material.SetFloat("_BrightnessVariationScale", BrightnessVariationScale);
        sr.material.SetFloat("_BrightnessPower", BrightnessPower);
        sr.material.SetFloat("_Brightness", Brightness);

        Vector2 offset;
        offset.x = transform.position.x / transform.localScale.x / parralax;
        offset.y = transform.position.z / transform.localScale.y / parralax;
        sr.material.SetVector("_Offset", offset);
    }
}
