using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BallManager : MonoBehaviour
{
    public float power = 1f;
    public LineRenderer lineRenderer;
    Vector3 pos_Input;
    Rigidbody2D rigid;
    bool canTouch = true;
    bool isTouched = false;
    private void Awake()
    {
        rigid = transform.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }    

    }
    public IEnumerator IEVelocity()
    {
        yield return new WaitUntil(()=>rigid.velocity.sqrMagnitude >0f);
        while(rigid.velocity.sqrMagnitude>10f)
        {
            //UIManager.Instance.SetSliderValue(rigid.velocity.sqrMagnitude / 100f);
            //Debug.Log(rigid.velocity.sqrMagnitude);
            yield return null;
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

    IEnumerator IEDrag()
    {
        while (mouseDown)
        {
            pos_drag = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10f)) - transform.position;
            pos_drag = Vector2.ClampMagnitude(pos_drag, 2.5f);
            
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
            Debug.Log(dir);
            rigid.AddForce(-dir * power);
            lineRenderer.enabled = false;
            mouseDown = false;
            StartCoroutine(IEVelocity());
        }

    }
}
