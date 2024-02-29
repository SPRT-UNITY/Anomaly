using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraEffect : MonoBehaviour
{
    [field: SerializeField, Range(0f, 1f)]
    float interpolationRate = 0.002f;

    [field: SerializeField]
    PostProcessVolume postProcessVolume;

    LensDistortion distortion;
    ChromaticAberration chromaticAberration;

    private void Awake()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out distortion);
        postProcessVolume.profile.TryGetSettings(out chromaticAberration);
    }
    // Start is called before the first frame update
    void Start()
    {
        postProcessVolume.isGlobal = true;
    }

    private void OnEnable()
    {
        StartCoroutine("Distortion");
    }

    private void OnDisable()
    {
        StopCoroutine("Distortion");
        distortion.intensity.value = 0f;
        distortion.scale.value = 1f;
        chromaticAberration.intensity.value = 0f;
    }

    IEnumerator Distortion() 
    {
        while(true) 
        {
            ApplyEffect();
            yield return new WaitForSeconds(0.01f);
        }
    }

    void ApplyEffect()
    {
        distortion.intensity.value = Mathf.Lerp(distortion.intensity.value, -100f, interpolationRate);
        distortion.scale.value = Mathf.Lerp(distortion.scale.value, 2f, interpolationRate);
        chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity, 1f, interpolationRate);
    }
}
