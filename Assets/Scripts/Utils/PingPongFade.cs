using UnityEngine;

public class PingPongFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup group;

    // Update is called once per frame
    void Update()
    {
        group.alpha = Mathf.SmoothStep(0, 1, Mathf.PingPong(Time.time, 1));
    }
}
