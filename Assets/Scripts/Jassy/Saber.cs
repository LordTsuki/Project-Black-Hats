using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class Saber : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rig;
    public CircleCollider2D trig;
    //public AudioSource audioAttack;
    public PlayerAttributesObject status;
    public DroneShoot droneShoot;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        trig = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && !status.attacking && !status.firstHit && !status.secondHit && !status.thirdHit)
        {
            status.attacking = true;
            FirstAttack();
            status.cooldown = status.attackCooldown;
        }
        else if (Input.GetKeyDown(KeyCode.K) && !status.attacking && status.firstHit && !status.secondHit && !status.thirdHit)
        {
            status.attacking = true;
            SecondAttack();
        }
        else if (Input.GetKeyDown(KeyCode.K) && !status.attacking && status.firstHit && status.secondHit && !status.thirdHit)
        {
            status.attacking = true;
            ThirdAttack();
        }
        else
        {
            if(status.cooldown > 0)
            {
                status.cooldown -= Time.deltaTime;
            }
            if (status.cooldown <= 0)
            {
                status.firstHit = false;
                status.secondHit = false;
                status.thirdHit = false;
            }
        }
    }
    private void Awake()
    {
        trig.enabled = false;
        status.attacking = false;
        status.firstHit = false;
        status.secondHit = false;
        status.thirdHit = false;
    }

    public void FirstAttack()
    {
        //audioAttack.Play();
        StartCoroutine(PerformFirstAttack());
    }
    private IEnumerator PerformFirstAttack()
    {
        status.firstHit = true;
        status.secondHit = false;
        status.thirdHit = false;
        trig.enabled = true;
        anim.SetTrigger("attack1");
        yield return new WaitForSeconds(status.firstHitTime);
        trig.enabled = false;
        status.attacking = false;
    }
    public void SecondAttack()
    {
        //audioAttack.Play();
        StartCoroutine(PerformSecondAttack());
    }
    private IEnumerator PerformSecondAttack()
    {
        status.secondHit = true;
        trig.enabled = true;
        anim.SetTrigger("attack2");
        yield return new WaitForSeconds(status.secondHitTime);
        trig.enabled = false;
        status.attacking = false;
    }
    public void ThirdAttack()
    {
        //audioAttack.Play();
        StartCoroutine(PerformThirdAttack());
    }
    private IEnumerator PerformThirdAttack()
    {
        status.thirdHit = true;
        trig.enabled = true;
        anim.SetTrigger("attack3");
        yield return new WaitForSeconds(status.thirdHitTime);
        trig.enabled = false;
        status.attacking = false;
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
                droneShoot.reflected = true;
                droneShoot.ReflectProjectile(transform.position);
            }
        }
    }
}
