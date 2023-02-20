using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rig;
    public PlayerAttributesObject status;
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!status.controller)
        {
            status.movement = 0;
        }
        else
        {
            Move();
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !status.isWallJumping)
        {
            status.movement = -1;
            status.left = true;
            status.right = false;
            if (!status.isSliding)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !status.isWallJumping)
        {
            status.movement = 1;
            status.left = false;
            status.right = true;
            if (!status.isSliding)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else
        {
            status.movement = 0;
        }

        if (status.isGrounded && !status.dashing)
        {
            rig.velocity = new Vector2(status.movement * status.speed, rig.velocity.y);
            if (status.movement == 0)
            {
                anim.SetInteger("transition", 1);
            }
            else
            {
                anim.SetInteger("transition", 2);
            }
        }
        else if (status.controller && !status.dashing)
        {
            if (status.movement != 0 && !status.isSliding)
            {
                rig.velocity = new Vector2(status.movement * status.speed, rig.velocity.y);
            }
        }
    }
}