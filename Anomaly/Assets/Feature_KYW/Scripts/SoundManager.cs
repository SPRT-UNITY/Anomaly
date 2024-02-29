using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletoneBase<SoundManager>
{
    public AudioSource bgmPlayer;
    public AudioSource sfxPlayer;

    private void Awake()
    {
        isDontDestroy = true;
        Init();
    }

    private void OnEnable()
    {
        bgmPlayer = ResourceManager.Instance.Instantiate("SoundPlayer/BGMPlayer",transform).GetComponent<AudioSource>();
        sfxPlayer = ResourceManager.Instance.Instantiate("SoundPlayer/SFXPlayer", transform).GetComponent<AudioSource>();
    }

    public void PlayBGM(AudioClip _clip)
    {
        bgmPlayer.clip = _clip;
        bgmPlayer.Play();
    }

    public void StopBGM()
    {
        bgmPlayer.Stop();
    }

    public void PlaySFX(AudioClip _clip)
    {
        sfxPlayer.PlayOneShot(_clip);
    }

}
