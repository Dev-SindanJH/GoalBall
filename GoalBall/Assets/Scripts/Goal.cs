using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject go_Lock;
    [SerializeField] GameObject go_Particle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Ball" && !isLock)
        {
            GameManager.Instance.StageClear();
            collision.GetComponent<BallManager>().ClearAct(this.GetComponent<RectTransform>().anchoredPosition);
            StartCoroutine(IEClear());
        }
    }
    IEnumerator IEClear()
    {
        yield return new WaitForSeconds(0.2f);
        UIManager.Instance.PopOnClear();
    }
    private bool isLock = false;
    public bool IsLock
    {
        get { return isLock; }
    }
    public void Lock()
    {
        isLock = true;
        go_Lock.SetActive(isLock);
        go_Particle.SetActive(!isLock);
    }
    public void UnLock()
    {
        isLock = false;
        go_Lock.SetActive(isLock);
        go_Particle.SetActive(!isLock);
    }
}
