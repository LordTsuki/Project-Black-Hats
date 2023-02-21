using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
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
        {
            rig.velocity = -direction * status.returnSpeed;
        }
    }
}
