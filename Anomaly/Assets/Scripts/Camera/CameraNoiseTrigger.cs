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
        //������ �߻� ��� �߰�
        _CameraManager.NoiseLocation.Add(_AnormalyObject.A_Location);
        _CameraManager.SetCameraNoise();
    }

    private void OnDisable()
    {
        //������ �߻� ��ҿ��� ����
        _CameraManager.NoiseLocation.Remove(_AnormalyObject.A_Location);
        _CameraManager.SetCameraNoise();
    }
}
