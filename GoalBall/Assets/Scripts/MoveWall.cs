using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExpandFunction;
public class MoveWall : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector2[] pos_target;
    RectTransform rt;
    private void Awake()
    {
        rt = transform.GetComponent<RectTransform>();
    }
    private void Start()
    {
        StartCoroutine(IEMove());
    }
    IEnumerator IEMove()
    {
        while(true)
        {
            for(int i=0; i<pos_target.Length; i++)
            {
                yield return StartCoroutine(rt.IE_MoveRect(pos_target[i], 1f / speed));
            }
        }    
    }
}

