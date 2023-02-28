using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class ReceiveDamage : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rig;
    public PlayerAttributesObject status;

    private void Awake()
    {
        status.health = status.maxHealth; 
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        anim.SetBool("death", false);
    }
    public void TakeDamage(float damage)
    {
        status.health -= damage;
        anim.SetTrigger("hit");

        if (status.health <= 0)
        {
            //anim.SetBool("death", true);
            SceneManager.LoadSceneAsync(3);
            SceneManager.LoadSceneAsync(4);
        }
    }
}