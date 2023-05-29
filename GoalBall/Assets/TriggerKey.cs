using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TriggerKey : SpecialWallManager
{
    [SerializeField] Goal goal;
    [SerializeField] ParticleSystem particle_Lock;
    Image img_lock;

    private void Awake()
    {
        img_lock = transform.GetComponent<Image>();
    }
    private void Start()
    {
        goal.Lock();
    }
    public override void TriggerEnter(Collider2D collision)
    {
        if(goal.IsLock)
        {
            img_lock.enabled = false;
            particle_Lock.Play();
            goal.UnLock();
        }
    }

    public override void TriggerStay(Collider2D collision)
    {
        throw new System.NotImplementedException();
    }
}
