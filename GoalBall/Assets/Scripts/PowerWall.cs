using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerWall : SpecialWallManager
{
    [SerializeField] float power;
    public override void TriggerEnter(Collider2D collision)
    {
        Vector2 normal = transform.up;
        Rigidbody2D rigid = collision.GetComponent<Rigidbody2D>();
        Vector2 reflection = Vector2.Reflect(rigid.velocity, normal);
        rigid.AddForce(reflection * power);
    }
}
