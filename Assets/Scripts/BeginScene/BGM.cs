using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    private static BGM instance;
    public static BGM Instance => instance;

    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        UpdateVolume(GameDataMgr.Instance.musicdata.musicVolume);
        UpdateOpen(GameDataMgr.Instance.musicdata.musicOn);
        
    }

    private void OnEnable()
    {
        GameDataMgr.Instance.OnMusicVolumeChanged += UpdateVolume;
        GameDataMgr.Instance.OnMusicOnChanged += UpdateOpen;

    }

    private void OnDisable()
    {
        GameDataMgr.Instance.OnMusicVolumeChanged -= UpdateVolume;
        GameDataMgr.Instance.OnMusicOnChanged -= UpdateOpen;

    }

    public void UpdateVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void UpdateOpen(bool isOpen)
    {
        audioSource.mute = !isOpen;
    }
}
