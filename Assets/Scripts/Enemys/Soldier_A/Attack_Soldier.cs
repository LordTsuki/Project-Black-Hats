/*using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class Attack_Soldier : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rig;
    public CircleCollider2D trig;
    public EnemyAttributesObject status;
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        trig = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        if (status.firstHit > 0)
        {
            status.firstHit -= Time.deltaTime;
        }
    }
    private void Awake()
    {
        trig.enabled = false;
    }

    public void FirstAttack()
    {
        trig.enabled = true;
        anim.SetTrigger("attack1");
        StartCoroutine(PerformFirstAttack());
    }
    private IEnumerator PerformFirstAttack()
    {
        yield return new WaitForSeconds(status.attackTime);
        trig.enabled = false;
        status.firstHit = status.attackCooldown;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var damageable = collision.GetComponent<EnemyReceiveDamage>();
        if (damageable != null)
        {
            damageable.TakeDamage(status.meeleDamage);
        }

        var deflectable = collision.GetComponent<IDeflectable>();
        if (deflectable != null)
        {
            deflectable.Deflect(transform.right);
            var droneShoot = collision.GetComponent<DroneShoot>();
            if (droneShoot != null)
            {
                droneShoot.ReflectProjectile(transform.position);
            }
        }
    }
}

*/