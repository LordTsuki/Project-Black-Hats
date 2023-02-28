using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReceiveDamage : MonoBehaviour
{
    public Animator anim;
    public EnemyAttributesObject status;
    public Drone drone;

    void Start()
    {
        status.health = status.maxHealth;
        anim = GetComponent<Animator>();
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
