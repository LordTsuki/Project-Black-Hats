using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rig;
    public PlayerAttributesObject status;
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //if(collision.gameObject.layer == 3)
        //{
        //    status.jumping = true;
        //    anim.SetInteger("transition", 4);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.layer == 3)
        //{
        //    anim.SetTrigger("land");
        //    status.jumping = false;
        //}
    }
}
