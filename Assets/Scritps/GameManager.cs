using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Ball")]
    [SerializeField] private int playerScore;
    public int PlayerScore { get; set; }
    
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject[] ballPosition;

    [Header("CueBall")]
    [SerializeField] private GameObject cueBall;
    [SerializeField] private GameObject ballLine;

    [Header("Shoot")]
    [SerializeField] private float xInput;
    [SerializeField] private float forceBall;

    [Header("Shoot")] 
    [SerializeField] private GameObject camera;
    
    [Header("TextUI")]
    [SerializeField] private TMP_Text scoreText;
    
    void Start()
    {
        instance = this;

        camera = Camera.main.gameObject;
        CameraBehindBall();
        
        UpdateScoreText();
        
        //SetBalls(BallColor.White, 0);
        SetBalls(BallColor.Red, 1);
        SetBalls(BallColor.Yellow, 2);
        SetBalls(BallColor.Green, 3);
        SetBalls(BallColor.Brown, 4);
        SetBalls(BallColor.Blue, 5);
        SetBalls(BallColor.Pink, 6);
        SetBalls(BallColor.Black, 7);
    }

    public void UpdateScoreText()
    {
        scoreText.text = $"Player Score: {PlayerScore}";
    }
    
    void Update()
    {
        RotataBall();
        
        if (Input.GetKey("space"))
        {
            ShootBall();
        }
        
        /*if (cueBall.GetComponent<Rigidbody>().velocity.magnitude == 0f && cueBall.GetComponent<Transform>().transform.position != new Vector3(0,0.5f,-27.38f))
        {
            StopBall();
        }*/

        if (Input.GetKey("backspace"))
        {
            StopBall();
        }
    }

    void SetBalls(BallColor color,int pos)
    {
        GameObject ball = Instantiate(ballPrefab, ballPosition[pos].transform.position, Quaternion.identity);
        Ball b = ball.GetComponent<Ball>();
        Rigidbody rd = ball.GetComponent<Rigidbody>();
        rd.drag = 1;
        b.SetColorAndPoint(color);
    }

    void RotataBall()
    {
        xInput = Input.GetAxis("Horizontal");
        cueBall.transform.Rotate(new Vector3(0f,xInput,0f));
    }

    void ShootBall()
    {
        camera.transform.parent = null;
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.AddRelativeForce(Vector3.forward * forceBall,ForceMode.Impulse);
        ballLine.SetActive(false);
    }

    void CameraBehindBall()
    {
        camera.transform.parent = cueBall.transform.transform;
        camera.transform.position = cueBall.transform.position + new Vector3(0f,50f,0f);
    }

    void StopBall()
    {
        camera.transform.parent = null;
            
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.velocity = Vector3.zero;
        rd.angularVelocity = Vector3.zero;
        
        cueBall.transform.eulerAngles = Vector3.zero;
        CameraBehindBall();
        camera.transform.eulerAngles = new Vector3(90f, 0f, -90f);
        ballLine.SetActive(true);
    }
    
}
