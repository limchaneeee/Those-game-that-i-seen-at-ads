using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum BgmType
{
    MainTheme
}

public enum SoundFXType
{
    Click,
    Move,
    GunShot,
    Die,
}

public class SoundManager : MonoSingleton<SoundManager>
{
    // How To Use? just code where you want
    // SoundManager.Instance.PlayBGM(BgmType.xxx)
    // SoundManager.Instance.PlaySFX(SoundFXType.xxx)
    
    [Header("Audio Source")] 
    private AudioSource bgmSource;
    private List<AudioSource> sfxSources;

    [Header("Audio Settings")] 
    [SerializeField] [Range(0f, 1f)] private float bgmVolume;
    [SerializeField] [Range(0f, 1f)] private float soundFXVolume;
    
    [Header("Audio Clips")]
    public List<AudioClip> bgmClips;
    public List<AudioClip> sfxClips;

    private Dictionary<BgmType, AudioClip> bgmDictionary;
    private Dictionary<SoundFXType, AudioClip> soundFXDictionary;

    public int soundFXPoolSize;

    public override void Awake()
    {
        base.Awake();

        InitializeAudioSources();
        InitializeDictionaries();
    }

    private void Start()
    {
        PlayBGM(BgmType.MainTheme);
    }

    private void InitializeAudioSources()
    {
        // Init BGM sources
        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.loop = true;
        
        // Init SFX sources
        sfxSources = new List<AudioSource>();
        for (int i = 0; i < soundFXPoolSize; i++)
        {
            AudioSource fxSource = gameObject.AddComponent<AudioSource>();
            fxSource.playOnAwake = false;
            sfxSources.Add(fxSource);
        }
    }

    private void InitializeDictionaries()
    {
        bgmDictionary = new Dictionary<BgmType, AudioClip>
        {
            { BgmType.MainTheme, bgmClips[0] }
        };

        soundFXDictionary = new Dictionary<SoundFXType, AudioClip>
        {
            {SoundFXType.Click, sfxClips[0] },
            { SoundFXType.Move, sfxClips[1]},
            { SoundFXType.GunShot , sfxClips[2]},
            { SoundFXType.Die , sfxClips[3]}
        };
    }

    public void PlayBGM(BgmType bgmType)
    {
        // this code will be delete(debug code)
        if (!bgmDictionary.TryGetValue(bgmType, out var clip))
        {
            Debug.LogError($"{bgmType} not found");
            return;
        }
        
        bgmSource.clip = clip;
        bgmSource.volume = bgmVolume;
        bgmSource.Play();
    }

    public void PlaySFX(SoundFXType sfxType)
    {
        if (soundFXDictionary == null)
        {
            return;
        }
        if (!soundFXDictionary.TryGetValue(sfxType, out var clip))
        {
            return;
        }

        AudioSource availableSource = null;

        // find source
        foreach (var source in sfxSources)
        {
            if (!source.isPlaying)
            {
                availableSource = source;
                break;
            }
        }

        if (availableSource != null)
        {
            availableSource.clip = clip;
            availableSource.volume = soundFXVolume;
            availableSource.Play();
        }
    }

    public void SetBgmVolume(float volume)
    {
        bgmVolume = volume;
        if(bgmSource != null)
        {
            bgmSource.volume = volume;
        }
    }

    public void SetSoundFXVolume(float volume)
    {
        soundFXVolume = volume;
        foreach(var source in sfxSources)
        {
            if(!source.isPlaying) continue;
            source.volume = volume;
        }
    }
    
    
}
