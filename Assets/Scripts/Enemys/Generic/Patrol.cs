using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public EnemyAttributesObject    status;
    public SpriteRenderer           enemieSprite;
    public Transform                enemie;
    public Transform[]              points;
    public int                      idTarget;
    void Start()
    {
        enemie.position = points[0].position;
        idTarget = 1;
    }

    void Update()
    {
        if(enemie != null)
        {
            enemie.position = Vector2.MoveTowards(enemie.position, points[idTarget].position, status.speed * Time.deltaTime);

            if (enemie.position.x == points[idTarget].position.x)
            {
                idTarget++;
                if(idTarget > 1)
                {
                    idTarget = 0;
                }

                if (points[idTarget].position.x < enemie.position.x && status.right == true)
                {
                    Flip();
                }
                else if (points[idTarget].position.x > enemie.position.x && status.right == false)
                {
                    Flip();
                }
            }
        }
    }

    void Flip()
    {
        status.right = !status.right;
        enemieSprite.flipX = !enemieSprite.flipX;
    }
}
