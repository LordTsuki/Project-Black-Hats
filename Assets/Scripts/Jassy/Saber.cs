using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class Saber : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rig;
    public CircleCollider2D trig;
    public PlayerAttributesObject status;
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        trig = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        if (status.firstHit > 0)
        {
            status.firstHit -= Time.deltaTime;
        }
        if (status.secondHit > 0)
        {
            status.secondHit -= Time.deltaTime;
        }
        if (status.thirdHit > 0)
        {
            status.thirdHit -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.K) && status.firstHit <= 0)
        {
            FirstAttack();
        }
        if (Input.GetKeyDown(KeyCode.K) && status.firstHit > 0 && status.secondHit <= 0)
        {
            SecondAttack();
        }
        if (Input.GetKeyDown(KeyCode.K) && status.secondHit > 0 && status.thirdHit <= 0)
        {
            ThirdAttack();
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
    public void SecondAttack()
    {
        trig.enabled = true;
        //anim 2
        StartCoroutine(PerformSecondAttack());
    }
    private IEnumerator PerformSecondAttack()
    {
        yield return new WaitForSeconds(status.attackTime);
        trig.enabled = false;
        status.firstHit = status.attackCooldown;
        status.secondHit = status.attackCooldown;
    }
    public void ThirdAttack()
    {
        trig.enabled = true;
        //anim 3
        StartCoroutine(PerformThirdAttack());
    }
    private IEnumerator PerformThirdAttack()
    {
        yield return new WaitForSeconds(status.attackTime);
        trig.enabled = false;
        status.firstHit = status.attackCooldown;
        status.secondHit = status.attackCooldown;
        status.thirdHit = status.attackCooldown;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var damageable = collision.GetComponent<EnemyReceiveDamage>();
        if(damageable != null)
        {
            damageable.TakeDamage(status.meeleDamage);
        }

        var deflectable = collision.GetComponent<IDeflectable>();
        if(deflectable != null)
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