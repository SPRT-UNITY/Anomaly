using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShowDirection
{
    Right,
    Left
}

public class CameraManager : SingletoneBase<CameraManager>
{
    public List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

    [HideInInspector] public int nowCameraNumber;
    [HideInInspector] public bool isProblem;
    [HideInInspector] public int outWorkCamera;

    [HideInInspector] public ShowDirection direction;

    public event Action CameraChange;//카메라 변경 시 이벤트

    private void Awake()
    {
        isDontDestroy = false;
        Init();

        nowCameraNumber = 0;

        isProblem = false;
        outWorkCamera = -1;
    }

    private void CheckCameraOK()
    {
        if (isProblem && nowCameraNumber == outWorkCamera)
        {
            ChangeCamera();
        }

        if (nowCameraNumber >= cameras.Count)
        {
            nowCameraNumber = 0;

            if (isProblem && nowCameraNumber == outWorkCamera)
            {
                ChangeCamera();
            }
        }
        else if(nowCameraNumber < 0)
        {
            nowCameraNumber = cameras.Count - 1;

            if (isProblem && nowCameraNumber == outWorkCamera)
            {
                ChangeCamera();
            }
        }
    }

    private void ChangeCamera()
    {
        if(direction == ShowDirection.Right)
        {
            nowCameraNumber++;
        }
        else
        {
            nowCameraNumber--;
        }
    }

    public void ShowCamera()
    {
        cameras[nowCameraNumber].gameObject.SetActive(false);
        ChangeCamera();

        CheckCameraOK();

        cameras[nowCameraNumber].gameObject.SetActive(true);

        CameraChange?.Invoke();
    }
}
