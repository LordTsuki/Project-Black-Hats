using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Elevator : MonoBehaviour
{
    public bool canMove = true;

    public float speed;
    public int startPoint;
    public Transform[] points;
    public int nowPoint;
    public bool reverse;
    void Start()
    {
        transform.position = points[startPoint].position;
        nowPoint = startPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, points[nowPoint].position) < 0.01f)
        {
            canMove = false;

            if (nowPoint == points.Length - 1)
            {
                reverse = true;
                nowPoint--;
                return;
            }
            else if (nowPoint == 0)
            {
                reverse = false;
                nowPoint++;
                return;
            }
            if (reverse)
            {
                nowPoint--;
            }
            else
            {
                nowPoint++;
            }
        }

        if(canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[nowPoint].position, speed * Time.deltaTime);
        }    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.W))
        {
            canMove = true;
        }
    }
}
