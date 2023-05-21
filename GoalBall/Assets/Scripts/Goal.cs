using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Ball")
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
}
