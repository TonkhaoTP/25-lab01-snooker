using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public GameObject ball;
    public Transform[] targets = new Transform[3];
    public int curTarget = 0;
    public Vector3 starPosition;
    public Collider _Collider;

    void Start()
    {
        starPosition = transform.position;
    }

    void Update() 
    {
        if((transform.position - targets[curTarget].transform.position).magnitude < 1f) {
            curTarget++;
            if(curTarget > 2) {
                curTarget = 0;
            }
        }
        
        transform.Translate(Vector3.forward * 10.0f * Time.deltaTime);
        transform.LookAt(targets[curTarget].position);

        if (Input.GetKeyDown("s"))
        {
            ball.transform.position = starPosition;
        }
    }
}
