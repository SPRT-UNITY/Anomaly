using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TitleMainCanvas : UIBase
{
    [field: Header("Buttons")]
    [SerializeField] private Button GameStartButton;
    [SerializeField] private Button GameOptionButton;
    [SerializeField] private Button GameEndButton;
    [SerializeField] private Button OptionExitButton;

    [field: Header("Panels")]
    [SerializeField] private GameObject OptionPanel;

    private void Awake()
    {
        GameEndButton.onClick.AddListener(() => TitleSceneManager.Instance.EndGame());
        GameOptionButton.onClick.AddListener(() => UIManager.Instance.OpenUI(OptionPanel));
        OptionExitButton.onClick.AddListener(() => UIManager.Instance.CloseUI(OptionPanel));
        GameStartButton.onClick.AddListener(() => UIManager.Instance.OpenUI(GetComponentInParent<TitleUICanvas>().TitleGameStartPanel));
    }
}
