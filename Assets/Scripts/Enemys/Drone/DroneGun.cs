using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DroneGun : MonoBehaviour
{
    public EnemyAttributesObject status;
    public Transform target;

    public GameObject projectile;
    public GameObject shotEffect;
    public Transform shotPoint;
    // Update is called once per frame
    void Update()
    {
        if(status.spot == true)
        {
            Vector2 lookDir = transform.position - target.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle + status.offset);
            Quaternion shoot = transform.rotation;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
            if (status.shootCooldown <= 0)
            {
                Instantiate(projectile, shotPoint.position, shoot);
                status.shootCooldown = status.startShootCooldown;
            }
            else
            {
                status.shootCooldown -= Time.deltaTime;
            }
        }
    }
}