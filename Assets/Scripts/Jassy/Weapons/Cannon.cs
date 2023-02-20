using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Components")]
    public GameObject projectile;
    public Transform cannonShotPoint;
    public PlayerAttributesObject status;

    void Update()
    {
        if (status.shootActuallyCooldown <= 0)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Instantiate(projectile, cannonShotPoint.position, transform.rotation);
                status.shootActuallyCooldown = status.shootCooldown;
            }
        }
        else
        {
            status.shootActuallyCooldown -= Time.deltaTime;
        }
    }
}