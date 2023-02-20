using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rig;
    public PlayerAttributesObject status;
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(status.dashing)
        {
            return;
        }
        DashStart();
    }

    void DashStart()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && status.canDash && status.controller)
        {
            anim.SetTrigger("dash");
            status.controller = false;
            StartCoroutine(Dash());
            anim.SetTrigger("dash");
            status.controller = true;
        }
    }

    IEnumerator Dash()
    {
        if (!status.dashing)
        {
            status.canDash = false;
            status.dashing = true;
            status.isIvulnerable = true;
            float originalGravity = rig.gravityScale;
            rig.gravityScale = 0f;
            if (status.right && !status.left)
            {
                rig.velocity = new Vector2(transform.localScale.x * status.dashingPower, 0f);
            }

            if (status.left && !status.right)
            {
                rig.velocity = new Vector2(transform.localScale.x * -status.dashingPower, 0f);
            }

            yield return new WaitForSeconds(status.dashingTime);
            rig.gravityScale = originalGravity;
            status.dashing = false;
            status.isIvulnerable = false;
            yield return new WaitForSeconds(status.dashingCooldown);
            status.canDash = true;
        }
    }
}