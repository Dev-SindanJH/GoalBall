using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExpandFunction;
public class WindWall : MonoBehaviour
{
    [SerializeField] RectTransform rt_wind;
    [SerializeField] float speed;
    [SerializeField] Vector2[] pos_target;
    Vector2 pos_origin;
    Wind wind;
    private void Awake()
    {
        pos_origin = rt_wind.anchoredPosition;
        wind = rt_wind.gameObject.AddComponent<Wind>();
    }
    private void Start()
    {
        StartCoroutine(IEMove());
    }

    IEnumerator IEMove()
    {
        while(true)
        {
            for (int i = 0; i < pos_target.Length; i++)
            {
                wind.dir = (pos_target[i] - rt_wind.anchoredPosition).normalized;
                yield return StartCoroutine(rt_wind.IE_MoveRect(pos_target[i], 1f / speed));
            }
        }
        
    }
    public class Wind : SpecialWallManager
    {
        public Vector2 dir;
        public override void TriggerEnter(Collider2D collision)
        {
            throw new System.NotImplementedException();
        }

        public override void TriggerStay(Collider2D collision)
        {
            collision.GetComponent<Rigidbody2D>().AddForce(dir*0.1f);
        }

    }
}
