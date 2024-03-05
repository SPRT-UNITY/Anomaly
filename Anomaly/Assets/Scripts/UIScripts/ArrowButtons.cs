using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowButtons : UIBase
{
    public void OnClickRightButton()
    {
        CameraManager.Instance.direction = ShowDirection.Right;
        CameraManager.Instance.ShowCamera();
    }

    public void OnClickLeftButton()
    {
        CameraManager.Instance.direction = ShowDirection.Left;
        CameraManager.Instance.ShowCamera();
    }
}
