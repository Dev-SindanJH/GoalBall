using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
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
    [SerializeField] AudioClip[] clips;
    Dictionary<string, AudioClip> list_clip = new();
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
        for(int i=0; i<clips.Length; i++)
        {
            list_clip.Add(clips[i].name, clips[i]);
        }
    }
    void Start()
    {
        if(PlayerPrefsManager.MusicOn)
        {
            audioSource.Play();
        } 
    }
    public void PlayBGM(bool _on)
    {
        if (_on)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }

    public void PlayOneShot(AudioClip _clip)
    {
        if (PlayerPrefsManager.SoundOn)
        {
            audioSource.PlayOneShot(_clip);
        }
    }
    public void PlayOneShot(string _name)
    {
        if(PlayerPrefsManager.SoundOn)
        {
            audioSource.PlayOneShot(list_clip[_name]);
        }
    }
}
