using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Minor : MonoBehaviour
{
    public PlayerAttributesObject status;
    public ItemsAttributesObject item;

    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            status.health += item.heal;
            if(status.health > status.maxHealth) 
            {
                status.health = status.maxHealth;
            }
        }
        Destroy(gameObject);
    }
}
