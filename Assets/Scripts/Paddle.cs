using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] KeyCode inputMoveUp;
    [SerializeField] KeyCode inputMoveDown;
    [SerializeField] float paddleSpeed = 2000.0f;

    private Rigidbody2D rigidBodyPaddle;

    private void Awake()
    {
        rigidBodyPaddle = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var paddleVelocity = rigidBodyPaddle.velocity;

        if (Input.GetKey(inputMoveUp))
        {
            paddleVelocity.y = paddleSpeed;
        }
        else if (Input.GetKey(inputMoveDown))
        {
            paddleVelocity.y = -paddleSpeed;
        }
        else
        {
            paddleVelocity.y = 0;
        }

        rigidBodyPaddle.velocity = paddleVelocity;
    }
}
