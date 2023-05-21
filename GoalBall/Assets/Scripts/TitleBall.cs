using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBall : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    Rigidbody2D rigid;
    private void Awake()
    {
        rigid = transform.GetComponent<Rigidbody2D>();
    }
    public void Touch()
    {
        if(rigid.velocity.sqrMagnitude<500f)
        {
            //particle.transform.position = Input.mousePosition;
            //particle.Play();
            rigid.AddForce(new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f)) * 150f);
        }
    }
}
