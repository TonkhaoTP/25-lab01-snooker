using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int playerScore;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject[] ballPosition;
    
    void Start()
    {
        instance = this;
        
        SetBalls(BallColor.White, 0);
        SetBalls(BallColor.Red, 1);
        SetBalls(BallColor.Yellow, 2);
    }
    
    void Update()
    {
        
    }

    void SetBalls(BallColor color,int pos)
    {
        GameObject ball = Instantiate(ballPrefab, ballPosition[pos].transform.position, Quaternion.identity);
        Ball b = ball.GetComponent<Ball>();
        b.SetColorAndPoint(color);
    }
}
