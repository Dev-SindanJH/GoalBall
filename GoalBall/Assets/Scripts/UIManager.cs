using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    [SerializeField] private GameObject go_Pop_Clear;
    [SerializeField] private GameObject go_Pop_Stage;
    [SerializeField] private GameObject go_Pop_GameOver;
    [SerializeField] private TextMeshProUGUI text_curStage;
    [SerializeField] private TextMeshProUGUI text_ClearStar;
    [SerializeField] private Slider slider_power;
    public void PopOnClear()
    {
        go_Pop_Clear.SetActive(true);
        text_ClearStar.text = "";
        for (int i=0; i<3; i++)
        {
            if(i<GetStar())
            {
                text_ClearStar.text += "★";
            }
            else
            {
                text_ClearStar.text += "☆";
            }
        }
    }
    public void PopOnCurrentPop()
    {
        text_curStage.text = $"Stage {GameManager.Instance.CurStage}";
        go_Pop_Stage.SetActive(true);
    }
    public void PopOnGameOver()
    {
        go_Pop_GameOver.SetActive(true);
    }
    public void SetSliderValue(float _value)
    {
        if(GameManager.Instance.IsPlaying)
        {
            slider_power.value = _value;
        }
    }
    public int GetStar()
    {
        if(slider_power.value > 0.66f)
        {
            return 3;
        }
        else if(slider_power.value > 0.33f)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }
}
