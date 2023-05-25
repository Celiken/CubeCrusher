using UnityEngine;
using UnityEngine.UI;

public class LoaderCallback : MonoBehaviour
{
    private bool isFirstUpdate = true;
    [SerializeField] private Image loadingBar;

    private void Update()
    {
        if (isFirstUpdate)
        {
            isFirstUpdate = false;
            StartCoroutine(Loader.LoadSceneAsyncCallback());
        }
        else
        {
            Loader.UpdateBar(loadingBar);
        }
    }
}
