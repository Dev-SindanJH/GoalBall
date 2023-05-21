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
}
