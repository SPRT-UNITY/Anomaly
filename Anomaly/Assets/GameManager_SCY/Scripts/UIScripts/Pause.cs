using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : UIBase
{
    [SerializeField] private GameObject OptionPop;

    private void Start()
    {
        GameManager.Instance.OnPause += PopPause;

        OptionPop.SetActive(false);
        gameObject.SetActive(false);
    }

    private void PopPause()
    {
        GameManager.Instance.PauseGame();
        gameObject.SetActive(true);
    }

    public void OnResumeButton()
    {
        GameManager.Instance.ResumeGame();
        CloseUI();
    }

    public void OnOptionButton()
    {
        OptionPop.SetActive(true);
    }

    public void OnQuitButton()
    {
        SceneManager.LoadScene("Title");
    }
}
