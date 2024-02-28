using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraNoiseTrigger : MonoBehaviour
{
    private AnormalyObject _AnormalyObject;
    private CameraManager _CameraManager;

    private void Awake()
    {
        _AnormalyObject = GetComponentInParent<AnormalyObject>();
        _CameraManager = CameraManager.Instance;
    }
    private void OnEnable()
    {
        //노이즈 발생 장소 추가
        _CameraManager.NoiseLocation.Add(_AnormalyObject.A_Location);
        _CameraManager.SetCameraNoise();
    }

    private void OnDisable()
    {
        //노이즈 발생 장소에서 제거
        _CameraManager.NoiseLocation.Remove(_AnormalyObject.A_Location);
        _CameraManager.SetCameraNoise();
    }
}
