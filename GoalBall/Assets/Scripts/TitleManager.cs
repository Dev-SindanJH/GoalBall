using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject[] go_MusicBtn;
    [SerializeField] GameObject[] go_SoundBtn;
    private void Start()
    {
        SetMusicBtn();

        SetSoundBtn();

    }
    public void SetMusicBtn()
    {
        if (PlayerPrefsManager.MusicOn)
        {
            go_MusicBtn[0].SetActive(true);
            go_MusicBtn[1].SetActive(false);
        }
        else
        {
            go_MusicBtn[0].SetActive(false);
            go_MusicBtn[1].SetActive(true);
        }
    }
    public void SetSoundBtn()
    {
        if (PlayerPrefsManager.SoundOn)
        {
            go_SoundBtn[0].SetActive(true);
            go_SoundBtn[1].SetActive(false);
        }
        else
        {
            go_SoundBtn[0].SetActive(false);
            go_SoundBtn[1].SetActive(true);
        }
    }
    public void OnOffMusic(bool _on)
    {
        PlayerPrefsManager.MusicOn = _on;
        SoundManager.Instance.PlayBGM(_on);
        SetMusicBtn();
    }
    public void OnOffSound(bool _on)
    {
        PlayerPrefsManager.SoundOn = _on;
        SetSoundBtn();
    }
    public void StartGame()
    {
        GameManager.Instance.StartGame(PlayerPrefsManager.LastStage);
    }
    public void PlayButtonSound()
    {
        SoundManager.Instance.PlayOneShot("Sound_Button");
    }
    public void PlayPage1Sound()
    {
        SoundManager.Instance.PlayOneShot("Sound_page1");

    }
    public void PlayPage2Sound()
    {
        SoundManager.Instance.PlayOneShot("Sound_page2");

    }
}
