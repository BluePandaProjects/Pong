using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float ballSpeed = 50.0f;
    [SerializeField] int startCountDown = 3;

    private Rigidbody2D rigidBodyBall;
    private AudioSource paddleCollisionlAudio;

    public bool isLaunched = false;

    private void Awake()
    {
        rigidBodyBall = GetComponent<Rigidbody2D>();
        paddleCollisionlAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!isLaunched)
        {
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        for (int startTimer = startCountDown; startTimer > 0; startTimer--)
        {
            isLaunched = true;

            float x = Random.Range(0, 2) == 0 ? -1 : 1;
            float y = Random.Range(0, 2) == 0 ? -1 : 1;

            rigidBodyBall.velocity = new Vector2(x, y).normalized * ballSpeed;
        }        
    }

    public void ResetBall()
    {
        rigidBodyBall.velocity = Vector2.zero;
        rigidBodyBall.position = new Vector2(960.0f, 540.0f);

        isLaunched = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            paddleCollisionlAudio.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GoalLeft")
        {
            GameManager.instance.ScorePoint(ScoringPaddle.PaddleRight);
        }
        else if (collision.tag == "GoalRight")
        {
            GameManager.instance.ScorePoint(ScoringPaddle.PaddleLeft);
        }

        ResetBall();
    }
}
