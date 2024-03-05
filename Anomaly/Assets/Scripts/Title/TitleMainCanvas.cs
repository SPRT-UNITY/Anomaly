using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

enum TitleMainButtonType
{
    Start,
    Option,
    End,
}


public class TitleMainCanvas : UIBase
{
    [field: Header("Buttons")]
    [SerializeField] private Button[] TitleMainButtons;
    [SerializeField] private Button OptionBackButton;

    [field: Header("Panels")]
    [SerializeField] private GameObject OptionPanel;

    private void Awake()
    {
        //Initialize Title Main Buttons
        InitTitleMainButton();
    }

    private void InitTitleMainButton()
    {
        foreach(var Button in TitleMainButtons)
        {
            OnPointerEnter_Button onPointerEnter = Button.AddComponent<OnPointerEnter_Button>();
            onPointerEnter.OnMouseImage = ResourceManager.Instance.Instantiate("Title/OnMouse_Image2", Button.transform);
            Button.onClick.AddListener(() => onPointerEnter.OnMouseImage_ActiveFalse());
        }

        TitleMainButtons[(int)TitleMainButtonType.Start].onClick.AddListener(() => UIManager.Instance.OpenUI(GetComponentInParent<TitleUICanvas>().TitleGameStartPanel));
        TitleMainButtons[(int)TitleMainButtonType.Option].onClick.AddListener(() => UIManager.Instance.OpenUI(OptionPanel));
        TitleMainButtons[(int)TitleMainButtonType.End].onClick.AddListener(() => TitleSceneManager.Instance.EndGame());
        OptionBackButton.onClick.AddListener(() => UIManager.Instance.CloseUI(OptionPanel));
    }
}
