using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float ballSpeed = 50.0f;

    private Rigidbody2D rigidBodyBall;
    private bool playGame = false;

    public bool isLaunched = false;


    private void Awake()
    {
        rigidBodyBall = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (Input.GetKey("space"))
        {
            if (!isLaunched)
            {
                StartGame();
            }
        }
        else if (playGame)
        {
            Invoke("LaunchBall", 1.5f);
        }
    }

    private void StartGame()
    {
        if (!isLaunched)
        {
            playGame = true;
            LaunchBall();
        }
       
    }

    private void LaunchBall()
    {
        isLaunched = true;

        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rigidBodyBall.velocity = new Vector2(x, y).normalized * ballSpeed;
    }

    public void ResetBall()
    {
        rigidBodyBall.velocity = Vector2.zero;
        rigidBodyBall.position = new Vector2(960, 540);  //This is very hacky

        isLaunched = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("GOAL!");

        ResetBall();
    }

}
