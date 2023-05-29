using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerWall : MonoBehaviour
{
    [SerializeField] float power;
    [SerializeField] RectTransform[] rt_Pillar;
    [SerializeField] LineRenderer line;       
    private void Awake()
    {
        for(int i=0; i<rt_Pillar.Length; i++)
        {
            line.SetPosition(i, rt_Pillar[i].anchoredPosition);
        }
        line.SetPosition(0, rt_Pillar[0].anchoredPosition);
        line.SetPosition(1, (rt_Pillar[0].anchoredPosition + rt_Pillar[1].anchoredPosition) * 0.5f);
        line.SetPosition(2, rt_Pillar[1].anchoredPosition);
        line.gameObject.AddComponent<PowerLine>();
        line.GetComponent<BoxCollider2D>().size = new Vector2(rt_Pillar[1].anchoredPosition.x - rt_Pillar[0].anchoredPosition.x, 25f);
    }


    public class PowerLine : SpecialWallManager
    {
        
        public override void TriggerEnter(Collider2D collision)
        {
            collision.GetComponent<Rigidbody2D>().velocity *= 1.2f;
        }

        public override void TriggerStay(Collider2D collision)
        {
            throw new System.NotImplementedException();
        }
    }
}
