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
        }
    }
    [SerializeField] private GameObject go_Pop_Clear;
    [SerializeField] private GameObject go_Pop_Stage;
    [SerializeField] private TextMeshProUGUI text_curStage;
    [SerializeField] private Slider slider_power;
    public void PopOnClear()
    {
        go_Pop_Clear.SetActive(true);
    }
    public void PopOnCurrentPop()
    {
        text_curStage.text = $"Stage {GameManager.Instance.CurStage}";
        go_Pop_Stage.SetActive(true);
    }
    public void SetSliderValue(float _value)
    {
        slider_power.value = _value;
    }
}
