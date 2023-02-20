using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public PlayerAttributesObject status;
    Transform check;
    // Start is called before the first frame update
    void Start()
    {
        check = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            status.lastCheck = check.position;
        }
    }
}