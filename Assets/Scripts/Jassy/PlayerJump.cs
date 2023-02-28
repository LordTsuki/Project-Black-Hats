using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerJump : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rig;
    public PlayerAttributesObject status;

    public RaycastHit2D leftCheck;
    public RaycastHit2D rightCheck;

    public RaycastHit2D leftWallCheck;
    public RaycastHit2D rightWallCheck;

    public AudioSource audioJump;

    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        status.leftWallCheck = leftWallCheck;
        status.rightWallCheck = rightWallCheck;
        Jump();
        WallJump();
        PhysicsCheck();
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && status.isGrounded && status.controller && !status.dashing && !status.isSliding)
        {
            audioJump.Play();
            rig.velocity = (Vector2.up * status.jumpForce);
            status.doubleJump = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && status.doubleJump && !status.isGrounded && status.controller && !status.dashing && !status.isSliding)
        {
            audioJump.Play();
            rig.velocity = (Vector2.up * status.doubleJumpForce);
            status.doubleJump = false;
        }
        if (!status.isGrounded)
        {
            anim.SetInteger("transition", 3);
        }
    }

    void WallJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (status.leftWallCheck && status.isSliding)
            {
                status.wallJumpTime = status.wallJumpCooldown;
                rig.velocity = new Vector2(status.wallJumpForce, status.jumpForce);
                status.doubleJump = false;
            }
            else if (status.rightWallCheck && status.isSliding)
            {
                status.wallJumpTime = status.wallJumpCooldown;
                rig.velocity = new Vector2(-status.wallJumpForce, status.jumpForce);
                status.doubleJump = false;
            }
        }

        if (status.wallJumpTime > 0)
        {
            status.isWallJumping = true;
            if (status.isWallJumping)
            {
                status.wallJumpTime -= Time.deltaTime;
            }
        }
        else
        {
            status.isWallJumping = false;
        }
    }

    void PhysicsCheck()
    {
        status.isGrounded = false;
        leftCheck = Raycast(new Vector2(status.footOffset[0].x, status.footOffset[0].y), Vector2.down, status.groundDistance, status.jumpLayerCollider);
        rightCheck = Raycast(new Vector2(status.footOffset[1].x, status.footOffset[1].y), Vector2.down, status.groundDistance, status.jumpLayerCollider);

        if(leftCheck || rightCheck)
        {
            status.isGrounded = true;
        }

        status.isSliding = false;
        leftWallCheck = Raycast(new Vector2(status.footOffset[2].x, status.footOffset[2].y), Vector2.left, status.wallCheckDistance, status.wallLayerCollider);
        rightWallCheck = Raycast(new Vector2(status.footOffset[3].x, status.footOffset[3].y), Vector2.right, status.wallCheckDistance, status.wallLayerCollider);

        if(leftWallCheck || rightWallCheck && !status.isGrounded)
        {
            status.isSliding = true;
        }
        if(status.isSliding && leftWallCheck && !status.isGrounded)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            anim.SetInteger("transition", 4);
        }
        if (status.isSliding && rightWallCheck && !status.isGrounded)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            anim.SetInteger("transition", 4);
        }
    }

    RaycastHit2D Raycast(Vector3 origin, Vector2 rayDirection, float length, LayerMask mask)
    {
        Vector3 pos = transform.position;

        RaycastHit2D hit = Physics2D.Raycast(pos + origin, rayDirection, length, mask);

        Color color = hit ? Color.red : Color.green;

        Debug.DrawRay(pos + origin, rayDirection * length, color);

        return hit;
    }
}
