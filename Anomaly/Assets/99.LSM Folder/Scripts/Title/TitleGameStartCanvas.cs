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
<<<<<<< Updated upstream
        StartHouseButton.onClick.AddListener(() => LoadSceneController.LoadScene("LSM_Scene2"));
=======
        InitButtons();
    }

    private void InitButtons()
    {
        //Button Object Settings
        foreach(var button in StartButtons)
        {
            OnPointerEnter_Button onPointerEnter = button.AddComponent<OnPointerEnter_Button>();
            onPointerEnter.OnMouseImage = ResourceManager.Instance.Instantiate("Title/OnMouse_Image", button.transform);
        }

        //Caching Buttons
        Button backButton = StartButtons[(int)TitleStartButtonType.Back];

        //Button OnClick AddListeners
        StartButtons[(int)TitleStartButtonType.House].onClick.AddListener(() => LoadSceneController.LoadScene("MainScene"));
        backButton.onClick.AddListener(() => backButton.GetComponent<OnPointerEnter_Button>().OnMouseImage_ActiveFalse());
>>>>>>> Stashed changes
    }
}
