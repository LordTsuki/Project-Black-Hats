using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Drone : MonoBehaviour
{
    int layerMask = 1 << 8;

    public Transform enemyCheck1;
    public Transform enemyCheck2;

    public EnemyAttributesObject status;
    public Rigidbody2D rig;

   // public AudioSource audioDrone;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        status.health = status.maxHealth;
        //audioDrone.Play();
    }
    void Update()
    {
        RaycastHit2D ray1 = Physics2D.Raycast(enemyCheck1.position, enemyCheck1.TransformDirection(0, -1, 0), status.distanceVision, layerMask);
        RaycastHit2D ray2 = Physics2D.Raycast(enemyCheck1.position, enemyCheck1.TransformDirection(1, 0, 0), status.distanceVision, layerMask);
        RaycastHit2D ray3 = Physics2D.Raycast(enemyCheck1.position, enemyCheck1.TransformDirection(1, -1, 0), status.distanceVision, layerMask);
        RaycastHit2D ray4 = Physics2D.Raycast(enemyCheck1.position, enemyCheck1.TransformDirection(0.41f, -1, 0), status.distanceVision, layerMask);
        RaycastHit2D ray5 = Physics2D.Raycast(enemyCheck1.position, enemyCheck1.TransformDirection(1, -0.41f, 0), status.distanceVision, layerMask);
        RaycastHit2D ray6 = Physics2D.Raycast(enemyCheck1.position, enemyCheck1.TransformDirection(0.2f, -1, 0), status.distanceVision, layerMask);
        RaycastHit2D ray7 = Physics2D.Raycast(enemyCheck1.position, enemyCheck1.TransformDirection(1, -0.2f, 0), status.distanceVision, layerMask);
        RaycastHit2D ray8 = Physics2D.Raycast(enemyCheck1.position, enemyCheck1.TransformDirection(0.7f, -1, 0), status.distanceVision, layerMask);
        RaycastHit2D ray9 = Physics2D.Raycast(enemyCheck1.position, enemyCheck1.TransformDirection(1, -0.7f, 0), status.distanceVision, layerMask);
        RaycastHit2D ground = Physics2D.Raycast(enemyCheck2.position, Vector2.down, status.distanceVision);

        Debug.DrawRay(enemyCheck1.position, enemyCheck1.TransformDirection(0, -10, 0), Color.red);
        Debug.DrawRay(enemyCheck1.position, enemyCheck1.TransformDirection(10, 0, 0), Color.red);
        Debug.DrawRay(enemyCheck1.position, enemyCheck1.TransformDirection(10, -10, 0), Color.green);
        Debug.DrawRay(enemyCheck1.position, enemyCheck1.TransformDirection(4.1f, -10, 0), Color.blue);
        Debug.DrawRay(enemyCheck1.position, enemyCheck1.TransformDirection(10, -4.1f, 0), Color.blue);
        Debug.DrawRay(enemyCheck1.position, enemyCheck1.TransformDirection(2f, -10, 0), Color.magenta);
        Debug.DrawRay(enemyCheck1.position, enemyCheck1.TransformDirection(10, -2f, 0), Color.magenta);
        Debug.DrawRay(enemyCheck1.position, enemyCheck1.TransformDirection(7f, -10, 0), Color.magenta);
        Debug.DrawRay(enemyCheck1.position, enemyCheck1.TransformDirection(10, -7f, 0), Color.magenta);

        if (ray1.collider == true || ray2.collider == true || ray3.collider == true || ray4.collider == true || ray5.collider == true || ray6.collider == true || ray7.collider == true || ray8.collider == true || ray9.collider == true)
        {
            status.spot = true;
            EnemySpot();
        }
        else
        {
            status.spot = false;
           // rig.velocity = new Vector2(status.movement * status.speed, rig.velocity.y);
            if (ground.collider == false && status.movement == 1)
            {
                transform.eulerAngles = new Vector2(0, 180);
                status.movement = -1;
            }
            else if (ground.collider == false && status.movement == -1)
            {
                transform.eulerAngles = new Vector2(0, 0);
                status.movement = 1;
            }
        }
    }

    void EnemySpot()
    {
        status.movement = 0;
        //Debug.Log("Hit Player");
    }
}