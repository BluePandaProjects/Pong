using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Header("Basic Paddle")] 
    [SerializeField] KeyCode inputMoveUp;
    [SerializeField] KeyCode inputMoveDown;
    [SerializeField] float paddleSpeed = 2000.0f;

    [Header("AI Paddle")]
    [SerializeField] bool useAI = false;
    [SerializeField] float paddleSpeedAI = 2000.0f;
    [SerializeField] Transform targetToTrack;

    private Rigidbody2D rigidBodyPaddle;

    private void Awake()
    {
        rigidBodyPaddle = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var paddleVelocity = rigidBodyPaddle.velocity;

        if (!useAI)
        {
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
        }
        else
        {
            float timeDeltaPaddleSpeed = paddleSpeedAI * Time.deltaTime;

            rigidBodyPaddle.transform.position = Vector2.MoveTowards(rigidBodyPaddle.transform.position,
                new Vector2(rigidBodyPaddle.position.x, targetToTrack.position.y), timeDeltaPaddleSpeed);
        }



        rigidBodyPaddle.velocity = paddleVelocity;
    }
}
