using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectProjectile : MonoBehaviour
{
    public float reflectionForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Vector2 reflection = Vector2.Reflect(collision.relativeVelocity, collision.contacts[0].normal);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(reflection * reflectionForce, ForceMode2D.Impulse);
        }
    }
}