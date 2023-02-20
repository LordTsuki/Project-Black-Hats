using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroneShoot : MonoBehaviour
{
    [Header("Status")]
    public float speed;
    public float lifeTime;
    public float distance;
    public float damage;
    public LayerMask whatisSolid;
    public float reflectionForce = 10f;

    [Header("Components")]
    public GameObject destroyEffect;
    public Vector2 aimPos;
    public GameObject groundHitParticle;
    Rigidbody2D rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Invoke("DestroyProjectile", lifeTime);
    }
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatisSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<ReceiveDamage>().TakeDamage(damage);
                DestroyProjectile();
            }
            //if (hitInfo.collider.CompareTag("Saber"))
            //{
            //    lifeTime = 0.5f;
            //}
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}