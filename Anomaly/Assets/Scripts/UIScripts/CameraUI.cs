using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraUI : UIBase
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI cameraText;
    private string cam;

    private void Start()
    {
        cam = "_Ä«¸Þ¶ó";

        UpdateCameraText();
        CameraManager.Instance.CameraChange += UpdateCameraText;
        GameManager.Instance.UpdateTimeText += UpdateTimeText;
    }

    private void UpdateCameraText()
    {
        cameraText.text = CameraManager.Instance.NowCameraName() + cam;
    }

    private void UpdateTimeText(int hour, int minute)
    {
        timeText.text = hour.ToString("00") + " : " + minute.ToString("00");
    }
}
