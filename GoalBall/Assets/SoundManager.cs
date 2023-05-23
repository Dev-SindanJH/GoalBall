using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            return instance;
        }
    }
    
    AudioSource audioSource;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        audioSource = transform.GetComponent<AudioSource>();
    }
    void Start()
    {
        if(PlayerPrefsManager.SoundOn)
        {
            audioSource.Play();
        } 
    }
    public void MuteBGM(bool _mute)
    {
        PlayerPrefsManager.SoundOn = _mute;
        if (_mute)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }
    }
}
