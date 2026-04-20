using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance;
    public AudioClip bgmClip;
    private AudioSource audioSource;
    private bool isBGMPlaying = false;

    void Awake()
    {
        // 单例模式实现
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.loop = true;
        audioSource.volume = 0.5f;
    }

    void Start()
    {
        PlayBGM();
    }

    public void PlayBGM()
    {
        if (!isBGMPlaying && bgmClip != null && audioSource != null)
        {
            audioSource.clip = bgmClip;
            audioSource.Play();
            isBGMPlaying = true;
        }
    }

    public void StopBGM()
    {
        if (isBGMPlaying && audioSource != null)
        {
            audioSource.Stop();
            isBGMPlaying = false;
        }
    }

    public void PauseBGM()
    {
        if (isBGMPlaying && audioSource != null)
        {
            audioSource.Pause();
        }
    }

    public void ResumeBGM()
    {
        if (!isBGMPlaying && audioSource != null)
        {
            audioSource.UnPause();
            isBGMPlaying = true;
        }
    }

    public void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = Mathf.Clamp01(volume);
        }
    }
}
