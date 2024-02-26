using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneController : MonoBehaviour
{
    [SerializeField] private Slider LoadingBar;
    public static string nextScene;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    public void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    private IEnumerator LoadSceneProcess()
    {
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(nextScene);
        loadScene.allowSceneActivation = false;

        float timer = 0f;
        while(!loadScene.isDone)
        {
            yield return null;

            if (loadScene.progress < 0.8f)
            {
                LoadingBar.value = loadScene.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                LoadingBar.value = Mathf.Lerp(0.8f, 1f, timer);
                if(LoadingBar.value >= 1f)
                {
                    loadScene.allowSceneActivation = true;
                    yield break;
                }
            }
        }

        yield return null;
    }
}
