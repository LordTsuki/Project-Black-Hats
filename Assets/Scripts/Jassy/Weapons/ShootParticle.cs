using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootParticle : MonoBehaviour
{
    public PlayerAttributesObject status;
    void Update()
    {
        status.particleDestroy -= Time.deltaTime;

        if(status.particleDestroy <= 0)
        {
            Destroy(gameObject);
            status.particleDestroy = status.particleDestroyCooldown;
        }
    }
}