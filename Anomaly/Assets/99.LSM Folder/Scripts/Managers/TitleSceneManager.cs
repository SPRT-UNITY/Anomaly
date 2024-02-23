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
        ResourceManager.Instance.Instantiate("Title/GameStart_Canvas");
        ResourceManager.Instance.Instantiate("Title/TitleMain_Canvas");
    }

    public void EndGame()
    {
        Debug.Log("���� ����");
        Application.Quit();
    }
}
