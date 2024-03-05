using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraVignetteEffect : CameraEffect
{
    Vignette vignette;
    ColorGrading colorGrading;

    private void Awake()
    {
        base.Awake();
        postProcessVolume.profile.TryGetSettings(out vignette);
        postProcessVolume.profile.TryGetSettings(out colorGrading);
    }
    protected override void InitProfiles()
    {
        vignette.intensity.value = 0f;
        colorGrading.saturation.value = 0f;
    }

    protected override void ApplyEffects()
    {
        vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 1f, interpolationRate);
        colorGrading.saturation.value = Mathf.Lerp(colorGrading.saturation.value, -100f, interpolationRate);
    }
}
