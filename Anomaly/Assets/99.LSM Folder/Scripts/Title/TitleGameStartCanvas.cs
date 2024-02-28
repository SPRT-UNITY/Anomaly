using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

enum TitleButtons
{
    House,
    Dungeon,
    School,
    Museum,
    Hospital,
    Office,
    Back
}

public class TitleGameStartCanvas : UIBase
{
    [SerializeField] private Button ExitButton;
    [SerializeField] private Button[] StartButtons;


    private void Awake()
    {
        ExitButton.onClick.AddListener(() => CloseUI());
        InitButtons();
    }

    private void InitButtons()
    {
        //Button Object Settings
        foreach(var button in StartButtons)
        {
            OnPointerEnter_Button onPointerEnter = button.AddComponent<OnPointerEnter_Button>();
            onPointerEnter.OnMouseImage = ResourceManager.Instance.Instantiate("Title/OnMouse_Image", button.transform);
            onPointerEnter.OnMouseImage.SetActive(false);
        }

        //Caching Buttons
        Button backButton = StartButtons[(int)TitleButtons.Back];

        //Button OnClick AddListeners
        StartButtons[(int)TitleButtons.House].onClick.AddListener(() => LoadSceneController.LoadScene("LSM_Scene2"));
        backButton.onClick.AddListener(() => backButton.GetComponent<OnPointerEnter_Button>().OnMouseImage_ActiveFalse());
    }
}
