using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Ball ball;
    [SerializeField] TextMeshProUGUI scorePaddleLeftText;
    [SerializeField] TextMeshProUGUI scorePaddleRightText;

    public int scorePaddleLeft = 0;
    public int scorePaddleRight = 0;

    private void Awake()
    {
        instance = this;
    }

    public void ScorePoint(ScoringPaddle scoringPaddle)
    {
        switch (scoringPaddle)
        {
            case ScoringPaddle.PaddleLeft:
                scorePaddleLeft++;

                break;
            case ScoringPaddle.PaddleRight:
                scorePaddleRight++;

                break;
        }

        ball.GetComponent<Ball>().ResetBall();
    }

    private void OnGUI()
    {
        scorePaddleLeftText.text = scorePaddleLeft.ToString();
        scorePaddleRightText.text = scorePaddleRight.ToString();
    }
}


public enum ScoringPaddle
{ 
    PaddleLeft,
    PaddleRight
}
