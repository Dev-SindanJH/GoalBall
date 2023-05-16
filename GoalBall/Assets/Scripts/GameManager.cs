using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    private int curStage;
    public int CurStage
    {
        get
        {
            return curStage;
        }
    }
    private void Start()
    {
        curStage = PlayerPrefs.GetInt("LastStage", 1);
        Debug.Log(curStage);
    }
    public void StageClear()
    {
        UIManager.Instance.PopOnClear();
        if(PlayerPrefs.GetInt("LastStage") < curStage)
        {
            PlayerPrefs.SetInt("LastStage", curStage + 1);
        }
    }
}

