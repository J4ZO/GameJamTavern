using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private List<AudioClip> audioMusic;
    
    
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayClip(int clipIndex, float volume = 1f)
    {
        _audioSource.PlayOneShot(audioClips[clipIndex]);
        _audioSource.volume = volume;
    }


    public void PlayMusic(int clipIndex, float volume = 1f)
    {
        _audioSource.Stop();
        _audioSource.volume = volume;
        _audioSource.loop = true;
        _audioSource.clip =  audioMusic[clipIndex];
        _audioSource.Play();
        
    }

    public void StopMusic()
    {
        _audioSource.Stop();
        _audioSource.loop = false;
    }
    
    
    
}
