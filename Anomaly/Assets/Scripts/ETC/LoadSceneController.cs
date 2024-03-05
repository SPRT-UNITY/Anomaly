using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneController : MonoBehaviour
{
    [SerializeField] private Slider LoadingBar;
    public static string nextScene;
    [SerializeField] private Button StartButton;

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

            if (loadScene.progress < 0.5f)
            {
                LoadingBar.value = loadScene.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                LoadingBar.value = Mathf.Lerp(0.5f, 1f, timer);
                if(LoadingBar.value >= 1f)
                {
                    StartButton.gameObject.SetActive(true);
                    StartButton.onClick.AddListener(() => loadScene.allowSceneActivation = true);
                    yield break;
                }
            }
        }
        yield return null;
    }
}
