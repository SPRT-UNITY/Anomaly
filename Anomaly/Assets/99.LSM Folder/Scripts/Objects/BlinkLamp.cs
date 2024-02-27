using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlinkLamp : MonoBehaviour
{
    //Light Objects
    [SerializeField] private Light _Light;

    [SerializeField] private MeshRenderer _MeshRenderer;

    //Blink Time
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

