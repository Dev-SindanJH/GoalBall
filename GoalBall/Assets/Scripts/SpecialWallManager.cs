using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpecialWallManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Ball")
        {
            TriggerEnter(collision);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name =="Ball")
        {
            TriggerStay(collision);
        }
    }
    public abstract void TriggerStay(Collider2D collision);
    public abstract void TriggerEnter(Collider2D collision);
}
