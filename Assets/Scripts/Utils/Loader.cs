using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class Loader
{
    public enum Scene
    {
        MenuScene,
        GameScene,
        LoadingScene
    }

    private static Scene targetScene;
    private static float progressValue;

    public static void Load(Scene targetScene)
    {
        progressValue = 0f;
        Loader.targetScene = targetScene;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static IEnumerator LoadSceneAsyncCallback()
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(targetScene.ToString());

        while (!loadOperation.isDone)
        {
            progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            yield return null;
        }
        progressValue = 1f;
    }

    public static void UpdateBar(Image loadingBar)
    {
        loadingBar.fillAmount = progressValue;
    }
    public static void LoaderCallback()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }
}
