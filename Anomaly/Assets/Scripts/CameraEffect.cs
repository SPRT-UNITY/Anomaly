using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraEffect : MonoBehaviour
{
    [field: SerializeField, Range(0f, 1f)]
    protected float interpolationRate = 0.002f;

    [field: SerializeField]
    protected PostProcessVolume postProcessVolume;

    protected void Awake()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
    }
    // Start is called before the first frame update
    void Start()
    {
        postProcessVolume.isGlobal = true;
        postProcessVolume.priority = 1;
    }

    private void OnEnable()
    {
        StartCoroutine("Distortion");
    }

    private void OnDisable()
    {
        // StopCoroutine("Distortion");
        // InitProfiles();
    }

    IEnumerator Distortion() 
    {
        while(true) 
        {
            ApplyEffects();
            yield return new WaitForSeconds(0.01f);
        }
    }

    protected virtual void InitProfiles() 
    {
    }

    protected virtual void ApplyEffects()
    {
    }

    private void OnDestroy()
    {
        StopCoroutine("Distortion");
        InitProfiles();
    }
}
