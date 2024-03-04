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
        if (isBGM)
        {
            SoundManager.Instance.StopBGM();
        }
    }

    public void PlayBGM()
    {
        SoundManager.Instance.PlayBGM(clip);
    }

    public void PlaySFX()
    {
        SoundManager.Instance.PlaySFX(clip);
    }
}
