using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsManager
{
    public static int LastStage
    {
        get
        {
            return PlayerPrefs.GetInt("LastStage", 1);
        }
        set
        {
            PlayerPrefs.SetInt("LastStage", value);
        }
    }
    public static int GetStarCount(int _stageNum)
    {
        return PlayerPrefs.GetInt($"Stage{_stageNum}_star", 0);       
    }
    public static void SetStarCount(int _stageNum, int _starCount)
    {
        if(PlayerPrefs.GetInt($"Stage{_stageNum}_star",0) < _starCount)
        {
            PlayerPrefs.SetInt($"Stage{_stageNum}_star", _starCount);
        }
    }
    public static bool MusicOn
    {
        get
        {
            return PlayerPrefs.GetInt("MusicOn", 1) == 1;
        }
        set
        {
            if(value)
            {
                PlayerPrefs.SetInt("MusicOn", 1);
            }
            else
            {
                PlayerPrefs.SetInt("MusicOn", 0);
            }
        }
    }
    public static bool SoundOn
    {
        get
        {
            return PlayerPrefs.GetInt("SoundOn", 1) == 1;
        }
        set
        {
            if(value)
            {
                PlayerPrefs.SetInt("SoundOn", 1);
            }
            else
            {
                PlayerPrefs.SetInt("SoundOn", 0);
            }
        }
    }

#if UNITY_EDITOR
    public static void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
    }
#endif
}
