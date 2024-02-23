using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleGameStartCanvas : UIBase
{
    [SerializeField] private Button ExitButton;

    private void Awake()
    {
        ExitButton.onClick.AddListener(() => CloseUI());
    }
}
