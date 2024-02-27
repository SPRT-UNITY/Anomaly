using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    [SerializeField] private CinemachineVirtualCamera[] ViewCam;
    [SerializeField] private int curCamNumber = 0;
<<<<<<< Updated upstream
    [SerializeField] private Anomaly_Location LookLocation = Anomaly_Location.Living_Room;
=======
    [field: SerializeField] public Anormaly_Location LookLocation {get; private set; } = Anormaly_Location.Living_Room;
>>>>>>> Stashed changes

    private RenderTexture RenderTexture_LowQuality;
    private GameObject CameraCanvas;
    private int viewCamCount;

    //CameraEvents
    public Action OnChangeCamera;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        viewCamCount = ViewCam.Length - 1;
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

    //Call OnChageCameraEventes When Change Look Camera Location;
    public void CallOnChangeCameraEvents()
    {
        OnChangeCamera?.Invoke();
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

<<<<<<< Updated upstream
        LookLocation = (Anomaly_Location)curCamNumber;
=======
        LookLocation = (Anormaly_Location)curCamNumber;
        CallOnChangeCameraEvents();
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
        LookLocation = (Anomaly_Location)curCamNumber;
=======
        LookLocation = (Anormaly_Location)curCamNumber;
        CallOnChangeCameraEvents();
    }

    public void ChangeCameraQuality_Low()
    {
        if (RenderTexture_LowQuality == null)
        {
            RenderTexture_LowQuality = ResourceManager.Instance.Load<RenderTexture>("Textures/PixelateRenderTexture");
        }

        if(CameraCanvas == null)
        {
            CameraCanvas = ResourceManager.Instance.Instantiate("UI/CameraCanvas");
        }

        CameraCanvas?.SetActive(true);
        Camera.main.targetTexture = RenderTexture_LowQuality;
    }

    public void ChangeCameraQuality_Base()
    {
        if (Camera.main.targetTexture != null)
        {
            Camera.main.targetTexture = null;
            CameraCanvas?.SetActive(false);
        }
>>>>>>> Stashed changes
    }
}
