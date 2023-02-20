using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReceiveDamage : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rig;
    public EnemyAttributesObject status;
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }
    public void TakeDamage(float damage)
    {
        status.health -= damage;
        //anim.SetTrigger("hit");

        if (status.health <= 0)
        {
            //anim death
            Destroy(gameObject);
        }
    }
}
