using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraDistortionEffect : CameraEffect
{
    LensDistortion distortion;
    ChromaticAberration chromaticAberration;

    private void Awake()
    {
        base.Awake();
        postProcessVolume.profile.TryGetSettings(out distortion);
        postProcessVolume.profile.TryGetSettings(out chromaticAberration);
    }

    protected override void InitProfiles()
    {
        distortion.intensity.value = 0f;
        distortion.scale.value = 1f;
        chromaticAberration.intensity.value = 0f;
    }

    protected override void ApplyEffects()
    {
        distortion.intensity.value = Mathf.Lerp(distortion.intensity.value, -100f, interpolationRate);
        distortion.scale.value = Mathf.Lerp(distortion.scale.value, 2f, interpolationRate);
        chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity, 1f, interpolationRate);
    }
}
