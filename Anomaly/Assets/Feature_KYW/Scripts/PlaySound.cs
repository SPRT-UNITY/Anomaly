using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] bool isBGM;

    public AudioClip clip;

    private void Start()
    {
        if (isBGM) PlayBGM();
    }

    void OnDisable()
    {
        SoundManager.instance.StopBGM();
    }

    public void PlayBGM()
    {
        SoundManager.instance.PlayBGM(clip);
    }

    public void PlaySFX()
    {
        SoundManager.instance.PlaySFX(clip);
    }
}
