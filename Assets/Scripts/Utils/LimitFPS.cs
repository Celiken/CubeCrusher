using UnityEngine;

public class LimitFPS : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }
}
