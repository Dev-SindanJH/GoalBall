using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudWall : SpecialWallManager
{
    public override void TriggerEnter(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().velocity *= 0.7f;
    }

    public override void TriggerStay(Collider2D collision)
    {
        throw new System.NotImplementedException();
    }
}
