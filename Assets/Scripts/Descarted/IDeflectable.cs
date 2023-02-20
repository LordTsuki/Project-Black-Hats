using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDeflectable : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rig;
    public EnemyAttributesObject status;

    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }
    public void Deflect(Vector2 direction)
    {
        if (direction.x > 0 && transform.right.x < 0 || (direction.x < 0 && transform.right.x > 0))
        {
            transform.right = -transform.right;
        }
        rig.velocity = transform.right * status.returnSpeed;
    }
}
