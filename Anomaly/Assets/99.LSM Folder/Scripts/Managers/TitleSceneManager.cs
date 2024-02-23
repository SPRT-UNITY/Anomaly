using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneManager : SingletoneBase<TitleSceneManager>
{
    private void Awake()
    {
        //Init Use Managers
        ResourceManager.Instance.Init();

        //Setting Use objects In Title
        Init_TitleScene();
    }

    private void Init_TitleScene()
    {
        ResourceManager.Instance.Instantiate("Title/TitleUICanvas");
        ResourceManager.Instance.Instantiate("Managers/UIManager");
    }

    public void EndGame()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }
}
