using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepController : MonoBehaviour
{
    public float speed = 5.0f;
    public float stepSize = 0.5f;

    private Vector3 lastStepPosition;

    void Start()
    {
        lastStepPosition = transform.position;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            Vector3 direction = new Vector3(horizontalInput, 0, verticalInput).normalized;
            transform.position += direction * speed * Time.deltaTime;

            if (Vector3.Distance(lastStepPosition, transform.position) > stepSize)
            {
                lastStepPosition = transform.position;
                PlayStepSound();
            }
        }
    }

    void PlayStepSound()
    {
        // Coloque aqui o código para tocar o som do passo do personagem
    }
}
