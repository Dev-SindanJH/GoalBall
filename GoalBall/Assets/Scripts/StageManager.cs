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
    [SerializeField] GameObject[] go_stagePrefabs;
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
        Instantiate(go_stagePrefabs[2], tr_stageParent);
        //Instantiate(go_stagePrefabs[], tr_stageParent);
    }
}
