using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleGameStartCanvas : UIBase
{
    [SerializeField] private Button ExitButton;
    [SerializeField] private Button StartHouseButton;

    private void Awake()
    {
        ExitButton.onClick.AddListener(() => CloseUI());
        StartHouseButton.onClick.AddListener(() => LoadSceneController.LoadScene("LSM_Scene2"));
    }
}
