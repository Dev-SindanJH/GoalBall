using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;
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
    [SerializeField,ReadOnly] private int curStage;
    public int CurStage
    {
        get
        {
            return curStage;
        }
    }
    private bool isPlaying = false;
    public bool IsPlaying
    {
        get
        {
            return isPlaying; 
        }
        set
        {
            isPlaying = value;
        }
    }
    private void Start()
    {
        curStage = PlayerPrefsManager.LastStage;
        //curStage = PlayerPrefs.GetInt("LastStage", 1);
    }
    public void StageClear()
    {
        if (isPlaying)
        {
            isPlaying = false;
            PlayerPrefsManager.SetStarCount(CurStage, UIManager.Instance.GetStar());
            if (PlayerPrefsManager.LastStage == curStage)
            {
                PlayerPrefsManager.LastStage = CurStage + 1;
            }
        }
    }
    public void GameOver()
    {
        if(isPlaying)
        {
            isPlaying = false;
            UIManager.Instance.PopOnGameOver();
        }
    }

    public void StartGame(int _stageNum=0)
    {
        if(_stageNum!=0)
        {
            curStage = _stageNum;
        }
        SceneManager.LoadScene("GameScene");

    }
    public void StartNextStage()
    {
        curStage++;
        StartGame();
    }
    public void StartRetry()
    {
        StartGame();
    }
    public void GoToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
    //============================ForDevelope============================
#if UNITY_EDITOR
    [Button("Reset PlayerPrefs")]
    public void ResetStage()
    {
        PlayerPrefsManager.DeleteAllData();
        curStage = PlayerPrefsManager.LastStage;
        SceneManager.LoadScene("TitleScene");
    }
#endif
}

