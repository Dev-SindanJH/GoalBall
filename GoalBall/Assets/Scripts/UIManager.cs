using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ExpandFunction;
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
        else
        {
            Destroy(this);
        }
    }
    [SerializeField] private GameObject go_Pop_Stage;
    [SerializeField] private GameObject go_Pop_GameOver;
    [SerializeField] private TextMeshProUGUI text_curStage;
    [Header("StarSlider")]
    [SerializeField] private Slider slider_star;
    [SerializeField] private Animator[] anim_sliderStars;

    [Header("ClearPoP")]
    [SerializeField] private GameObject go_Pop_StageClear;
    [SerializeField] private TextMeshProUGUI text_CompleteStage;
    [SerializeField] private GameObject[] go_Stars;

    [Header("PowerSlider")]
    [SerializeField] Slider slider_Power;

    int currentStar = 0;
#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.StartRetry();
        }
    }
#endif
    private void Start()
    {
        SeTextStage();
    }
    public void PopOnClear()
    {
        go_Pop_StageClear.SetActive(true);
        SoundManager.Instance.PlayOneShot("Sound_Clear");
        text_CompleteStage.text = $"<size=100>Stage {GameManager.Instance.CurStage}</size>\nCompleted!";
        for (int i=0; i<3; i++)
        {
            if(i<GetStar())
            {
                go_Stars[i].SetActive(true);
            }
            else
            {
                go_Stars[i].SetActive(false);
            }
        }
    }
    public void PopOnCurrentPop()
    {
        text_CompleteStage.text = $"Stage {GameManager.Instance.CurStage}";
        go_Pop_Stage.SetActive(true);
    }
    public void PopOnGameOver()
    {
        go_Pop_GameOver.SetActive(true);
    }
    Coroutine co_slider = null;
    public void SetSliderValue(float _value)
    {
        if(GameManager.Instance.IsPlaying)
        {
            if(co_slider != null)
            {
                StopCoroutine(co_slider);
            }
            if(_value >= 0.5f)
            {
                currentStar = 2;
                anim_sliderStars[1].SetTrigger("On");
            }
            if(_value>=1f)
            {
                currentStar = 3;
                anim_sliderStars[2].SetTrigger("On");
            }
            co_slider = StartCoroutine(slider_star.IE_SetSliderValue(_value, 0.2f));
            //slider_star.value = _value;
        }
    }
    public int GetStar()
    {
        return currentStar;
    }

    public void NextStage()
    {
        GameManager.Instance.StartNextStage();
    }
    public void RetryStage()
    {
        GameManager.Instance.StartRetry();
    }
    public void GoToTitle()
    {
        GameManager.Instance.GoToTitle();
    }
    public void StartShoot()
    {
        currentStar = 1;
        anim_sliderStars[0].SetTrigger("On");
    }

    public void SetValue_PowerSlider(float _value)
    {
        slider_Power.value = _value;
    }
    public float GetValue_PowerSlider()
    {
        return slider_Power.value;
    }
    public void SeTextStage()
    {
        text_curStage.text = $"Stage {GameManager.Instance.CurStage}";
    }
}
