using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Ball")]
    [SerializeField] private int playerScore;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject[] ballPosition;

    [Header("CueBall")]
    [SerializeField] private GameObject cueBall;
    [SerializeField] private GameObject ballLine;

    [Header("Shoot")]
    [SerializeField] private float xInput;
    [SerializeField] private float forceBall;
    void Start()
    {
        instance = this;
        
        SetBalls(BallColor.White, 0);
        SetBalls(BallColor.Red, 1);
        SetBalls(BallColor.Yellow, 2);
        SetBalls(BallColor.Green, 3);
        SetBalls(BallColor.Brown, 4);
        SetBalls(BallColor.Blue, 5);
        SetBalls(BallColor.Pink, 6);
        SetBalls(BallColor.Black, 7);
    }
    
    void Update()
    {
        RotataBall();
        
        if (Input.GetKey("space"))
        {
            ShootBall();
        }
    }

    void SetBalls(BallColor color,int pos)
    {
        GameObject ball = Instantiate(ballPrefab, ballPosition[pos].transform.position, Quaternion.identity);
        Ball b = ball.GetComponent<Ball>();
        b.SetColorAndPoint(color);
    }

    void RotataBall()
    {
        xInput = Input.GetAxis("Horizontal");
        cueBall.transform.Rotate(new Vector3(0f,xInput,0f));
    }

    void ShootBall()
    {
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.AddRelativeForce(Vector3.forward * forceBall,ForceMode.Impulse);
        ballLine.SetActive(false);
    }
}
