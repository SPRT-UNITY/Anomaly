using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlinkLamp : MonoBehaviour
{
    //불빛 오브젝트
    [SerializeField] private Light _Light;

    //이미션 오브젝트
    [SerializeField] private MeshRenderer _MeshRenderer;

    //Blink 주기
    [SerializeField][Range(0.1f, 3f)] private float _blinkDealy;

    private void OnEnable()
    {
        StartCoroutine(StartBlink());
    }

    IEnumerator StartBlink()
    {
        Material material = _MeshRenderer.material;

        while (true)
        {
            _Light.enabled = false;
            material.DisableKeyword("_EMISSION");
            yield return new WaitForSeconds(_blinkDealy);

            _Light.enabled = true;
            material.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(_blinkDealy);
        }
    }
}

