using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExpandFunction;
public class BallManager : MonoBehaviour
{
    [SerializeField] int WallCount;

    public LineRenderer lineRenderer;
    Vector3 pos_Input;
    Rigidbody2D rigid;
    bool canTouch = true;
    bool isTouched = false;

    float baseHeight = 720f;  // 기준 높이
    float baseWidth = 1280f;  // 기준 너비
    float forceScale;
    private void Awake()
    {
        rigid = transform.GetComponent<Rigidbody2D>();
        //float resolutionRatio = Screen.height / baseHeight;  // 해상도 비율
        //forceScale = resolutionRatio * (baseWidth / Screen.width) * 0.3f;
    }
    public IEnumerator IEVelocity()
    {
        yield return new WaitUntil(()=>rigid.velocity.sqrMagnitude >0f);
        // 만약 시작벨류가 0.7이야, 그러면 0.7 : velocity
        // startVelocity : startValue = current_velocity : currentValue
        // currentValue = current_velocity*startValue / startVelocity
        float startVelocity = rigid.velocity.sqrMagnitude;
        float startValue = UIManager.Instance.GetValue_PowerSlider();
        System.Diagnostics.Stopwatch stopwatch = new();
        stopwatch.Start();
        while (rigid.velocity.sqrMagnitude>0.1f)
        {
            UIManager.Instance.SetValue_PowerSlider(rigid.velocity.sqrMagnitude * startValue / startVelocity);
            //UIManager.Instance.SetValue_PowerSlider(rigid.velocity.sqrMagnitude);
            //UIManager.Instance.SetSliderValue(rigid.velocity.sqrMagnitude / 100f);
            //Debug.Log(rigid.velocity.sqrMagnitude);
            yield return null;
        }
        stopwatch.Stop();
        Debug.Log(stopwatch.ElapsedMilliseconds+"ms");
        UIManager.Instance.SetValue_PowerSlider(rigid.velocity.sqrMagnitude * startValue / startVelocity);

        GameManager.Instance.GameOver();
    }
    int curBreakWall = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            curBreakWall++;
            UIManager.Instance.SetSliderValue(curBreakWall / (float)WallCount);
        }
    }
    public void OnMouseDown()
    {
        if(canTouch)
        {
            canTouch = false;
            isTouched = true;
            pos_Input = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10f)) - transform.position;
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, Vector3.zero);
            mouseDown = true;
            StartCoroutine(IEDrag());
        }
    }
    bool mouseDown = false;
    Vector3 pos_drag;
    public void ClearAct(Vector2 pos_Goal)
    {
        RectTransform rt = transform.GetComponent<RectTransform>();
        rigid.velocity = Vector2.zero;
        StartCoroutine(rt.IE_SetScale(Vector3.zero, 0.2f));
        StartCoroutine(rt.IE_MoveRect(pos_Goal, 0.2f));
    }


    IEnumerator IEDrag()
    {
        while (mouseDown)
        {
            pos_drag = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10f)) - transform.position;
            pos_drag = Vector2.ClampMagnitude(pos_drag, 2.5f);
            UIManager.Instance.SetValue_PowerSlider(pos_drag.magnitude/2.5f);
            lineRenderer.SetPosition(1, -pos_drag);
            yield return null;
        }
    }
    public void OnMouseUp()
    {
        if(isTouched)
        {
            isTouched = false;
            Vector3 dir = (pos_drag - pos_Input);
            rigid.AddForce(-dir);

            lineRenderer.enabled = false;
            mouseDown = false;
            GameManager.Instance.IsPlaying = true;
            UIManager.Instance.StartShoot();
            StartCoroutine(IEVelocity());
        }

    }
}
