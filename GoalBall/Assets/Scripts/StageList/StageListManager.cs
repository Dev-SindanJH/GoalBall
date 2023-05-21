using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Sirenix.OdinInspector;
using TMPro;
public class StageListManager : MonoBehaviour
{
    [SerializeField,ReadOnly] int count_Stage;
    [SerializeField] TextMeshProUGUI text_starCount;
    [SerializeField] Transform tr_StageListParent;
    List<StageList_Info> StageInfo;
    private void Awake()
    {
        count_Stage = Resources.LoadAll("Prefabs/Stages").Length;
        StageInfo = tr_StageListParent.GetComponentsInChildren<StageList_Info>().ToList();
        for (int i = 0; i < StageInfo.Count; i++)
        {
            StageInfo[i].gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        int count_star=0;
        for (int i = 0; i < count_Stage; i++)
        {
            if(i>=StageInfo.Count)
            {
                StageInfo.Add(Instantiate(StageInfo[0], tr_StageListParent));
            }
            StageInfo[i].gameObject.SetActive(true);
            StageInfo[i].SetInfo(i + 1);
            if(i<PlayerPrefsManager.LastStage)
            {
                count_star += PlayerPrefsManager.GetStarCount(i+1);
            }
        }
        text_starCount.text = $"{count_star}/{count_Stage * 3}";
    }
}
