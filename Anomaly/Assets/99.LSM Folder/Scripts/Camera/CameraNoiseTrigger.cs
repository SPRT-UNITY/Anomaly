using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraNoiseTrigger : MonoBehaviour
{
    [SerializeField] private AnormalyObject _AnormalyObject;
    [SerializeField] private CameraManager _CameraManager;

    private void Awake()
    {
        _AnormalyObject = GetComponentInParent<AnormalyObject>();
    }
    private void OnEnable()
    {
        if (_CameraManager == null)
            _CameraManager = CameraManager.Instance;

        _CameraManager.CameraChange += SetCameraNoise;
        SetCameraNoise();
    }

    private void OnDisable()
    {
        _CameraManager.ChangeCameraQuality_Base();
        _CameraManager.CameraChange -= SetCameraNoise;
    }

    private void SetCameraNoise()
    {
        if (_CameraManager.CurCameraLookLocation == _AnormalyObject.A_Location)
        {
            Debug.Log("노이즈 장소 맞음");
            _CameraManager.ChangeCameraQuality_Noise();
        }
        else {

            Debug.Log("노이즈 장소 아님");
            _CameraManager.ChangeCameraQuality_Base();
        }
    }
}
