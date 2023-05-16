using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalWall : SpecialWallManager
{
    [SerializeField] RectTransform rt_Enter;
    [SerializeField] RectTransform rt_Exit;
    public override void TriggerEnter(Collider2D collision)
    {
        collision.GetComponent<RectTransform>().anchoredPosition = rt_Exit.anchoredPosition;
    }

    
}
