using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StageList_Info : MonoBehaviour
{
    [SerializeField] Button btn_startStage;
    [SerializeField] GameObject go_StartSet;
    [SerializeField] GameObject[] go_stars;
    [SerializeField] TextMeshProUGUI text_StageNum;
    [SerializeField] GameObject go_Lock;
    int stageNum=0;
    public void SetInfo(int _stageNum)
    {
        stageNum = _stageNum;
        for(int i=0; i<3; i++)
        {
            if(i<PlayerPrefsManager.GetStarCount(stageNum))
            {
                go_stars[i].SetActive(true);
            }
            else
            {
                go_stars[i].SetActive(false);
            }
            text_StageNum.text = $"Stage {stageNum}";
        }
        
        // Clear
        if(PlayerPrefsManager.GetStarCount(stageNum) > 0)
        {
            btn_startStage.interactable = true;
            go_StartSet.SetActive(true);
            go_Lock.SetActive(false);
        }
        else
        {
            btn_startStage.interactable = false;
            go_StartSet.SetActive(false);
            go_Lock.SetActive(true);
        }
    }
    public void StartGame()
    {
        GameManager.Instance.StartGame(stageNum);
    }
}
