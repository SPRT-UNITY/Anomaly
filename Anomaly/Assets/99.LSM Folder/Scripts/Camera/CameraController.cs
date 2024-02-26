using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] ViewCam;
    [SerializeField] private int curCamNumber = 0;
    [SerializeField] private Anormaly_Location LookLocation = Anormaly_Location.Living_Room;

    private int viewCamCount;

    private void Start()
    {
        viewCamCount = ViewCam.Length -1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ShowNextCam();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            ShowBeforeCam();
        }
    }

    public void ShowNextCam()
    {
        if (curCamNumber < viewCamCount)
        {
            ViewCam[curCamNumber++].Priority = 0;
            ViewCam[curCamNumber].Priority = 10;
        }
        else
        {
            curCamNumber = 0;
            ViewCam[curCamNumber].Priority = 10;
        }

        LookLocation = (Anormaly_Location)curCamNumber;
    }

    public void ShowBeforeCam()
    {
        if (curCamNumber > 0)
        {
            ViewCam[curCamNumber--].Priority = 0;
            ViewCam[curCamNumber].Priority = 10;
        }
        else
        {
            ViewCam[curCamNumber].Priority = 0;
            curCamNumber = viewCamCount;
            ViewCam[curCamNumber].Priority = 10;
        }

        LookLocation = (Anormaly_Location)curCamNumber;
    }
}
