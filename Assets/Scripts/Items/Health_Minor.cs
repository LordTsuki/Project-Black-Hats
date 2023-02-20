using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Minor : MonoBehaviour
{
    public PlayerAttributesObject status;
    public ItemsAttributesObject item;
    public Collider2D col;

    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
