using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float ballSpeed = 50.0f;

    private Rigidbody2D rigidBodyBall;

    public bool isLaunched = false;

    private void Awake()
    {
        rigidBodyBall = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey("space") && !isLaunched) 
        {
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
        rigidBodyBall.position = new Vector2(980, 480);
    }
}
