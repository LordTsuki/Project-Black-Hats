using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float distance;

    bool isRight;

    public Transform groundCheck;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D ground = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);

        if(ground.collider == false)
        {
            if(isRight == true)
            {
                transform.eulerAngles = new Vector2(0, 0);
                isRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
                isRight = true;
            }
        }
    }
}
