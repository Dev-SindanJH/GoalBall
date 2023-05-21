using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private static StageManager instance;
    public static StageManager Instance
    {
        get
        {
            return instance;
        }
    }
    
    [SerializeField] Transform tr_stageParent;
    GameObject go_prefab;
    //[SerializeField] GameObject[] go_stagePrefabs;
    private void Awake()
    {
        if(instance == null)
        {
             instance = this;
        }
    }
    private void OnDestroy()
    {
        instance = null;
    }
    private void Start()
    {
        MakeStage();
    }

    public void MakeStage()
    {
        go_prefab = Resources.Load<GameObject>($"Prefabs/Stages/Stage{GameManager.Instance.CurStage}");
        Instantiate(go_prefab, tr_stageParent);
        //Instantiate(go_stagePrefabs[], tr_stageParent);
    }

}
