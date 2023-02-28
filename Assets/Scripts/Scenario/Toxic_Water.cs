using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Toxic_Water : MonoBehaviour
{
    public PlayerAttributesObject status;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            status.health -= status.maxHealth * 0.20f;
            player.transform.position = status.lastCheck;
            if(status.health <= 0)
            {
                SceneManager.LoadSceneAsync(3);
                SceneManager.LoadSceneAsync(4);
            }
        }
    }
}
