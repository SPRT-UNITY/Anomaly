using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNoiseTrigger : MonoBehaviour
{
    [SerializeField] private Anormaly_Location _CurCameraLookLocation = Anormaly_Location.Library;
    [SerializeField] private AnormalyObject _AnormalyObject;

    private void Start()
    {
        _AnormalyObject = GetComponentInParent<AnormalyObject>();
        _CurCameraLookLocation = CameraController.Instance.LookLocation;
        CameraController.Instance.OnChangeCamera += ChangeCurLookLocation;
    }

    private void ChangeCurLookLocation()
    {
        _CurCameraLookLocation = CameraController.Instance.LookLocation;
    }

    private void StartCameraNoise()
    {
    }
}
