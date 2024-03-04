using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public enum ShowDirection
{
    Right,
    Left
}

public enum PostProcessProfileType
{
    Bloom,
    Noise
}

public class CameraManager : SingletoneBase<CameraManager>
{
    public List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

    [HideInInspector] public int nowCameraNumber;
    [HideInInspector] public bool isProblem;
    [HideInInspector] public int outWorkCamera;

    [HideInInspector] public ShowDirection direction;

    [field: SerializeField] public Anomaly_Location CurCameraLookLocation { get; private set; }
    [HideInInspector] public List<Anomaly_Location> NoiseLocation;

    //PostProcess
    private PostProcessVolume _CameraPostPorcessVolume;
    [HideInInspector] public List<PostProcessProfile> _PostPorcessProfiles;

    //Evnets
    public event Action CameraChange;

    private void Awake()
    {
        isDontDestroy = false;

        nowCameraNumber = 0;
        CurCameraLookLocation = CameraLookLocation(nowCameraNumber);

        isProblem = false;
        outWorkCamera = -1;

        _CameraPostPorcessVolume = GetComponent<PostProcessVolume>();
        _PostPorcessProfiles.Add(ResourceManager.Instance.Load<PostProcessProfile>("Lighting/Default"));
        _PostPorcessProfiles.Add(ResourceManager.Instance.Load<PostProcessProfile>("Lighting/Noise"));
        CameraChange += SetCameraNoise;

        InitiateCamera();
    }

    //카메라가 사용가능한지 확인
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
        else if (nowCameraNumber < 0)
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
        if (direction == ShowDirection.Right)
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
        CurCameraLookLocation = CameraLookLocation(nowCameraNumber);

        CameraChange?.Invoke();
    }

    public void InitiateCamera()
    {
        cameras[nowCameraNumber].gameObject.SetActive(true);

        CameraChange?.Invoke();
    }

    public void ChangeCameraQuality_Noise()
    {
        _CameraPostPorcessVolume.profile = _PostPorcessProfiles[(int)PostProcessProfileType.Noise];
    }

    public void ChangeCameraQuality_Base()
    {
        _CameraPostPorcessVolume.profile = _PostPorcessProfiles[(int)PostProcessProfileType.Bloom];
    }

    //NoiseLocation 리스트에 존재하면 노이즈 발생
    public void SetCameraNoise()
    {
        if (NoiseLocation != null)
        {
            List<Anomaly_Location> noiseLocation = NoiseLocation;
            bool isNoise = false;

            foreach (var loaction in noiseLocation)
            {
                if (loaction == CurCameraLookLocation)
                {
                    isNoise = true;
                }
            }

            if (isNoise)
                ChangeCameraQuality_Noise();

            else ChangeCameraQuality_Base();
        }
    }

    public string NowCameraName()
    {
        return cameras[nowCameraNumber].GetComponent<CameraName>().GetCameraName();
    }

    public Anomaly_Location CameraLookLocation(int index)
    {
        return cameras[index].GetComponent<CameraName>().location;
    }
}
