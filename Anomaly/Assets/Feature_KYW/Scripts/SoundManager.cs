using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmPlayer;
    public AudioSource sfxPlayer;

    public static SoundManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(AudioClip _clip)
    {
        bgmPlayer.clip = _clip;
        bgmPlayer.Play();
    }

    public void PlaySFX(AudioClip _clip)
    {
        sfxPlayer.PlayOneShot(_clip);
    }
}
